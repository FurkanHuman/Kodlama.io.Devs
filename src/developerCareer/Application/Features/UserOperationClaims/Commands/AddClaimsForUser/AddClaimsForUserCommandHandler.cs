using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.AltServices.UserOperationClaimService;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.AddClaimsForUser
{
    public class AddClaimsForUserCommandHandler : IRequestHandler<AddClaimsForUserCommand, AddClaimsForUserDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public AddClaimsForUserCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IUserOperationClaimService userOperationClaimService, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimService = userOperationClaimService;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<AddClaimsForUserDto> Handle(AddClaimsForUserCommand request, CancellationToken cancellationToken)
        {
            IList<Guid> userOperationClaimIds = new List<Guid>();

            await _userOperationClaimBusinessRules.CheckIfUserMailExists(request.UserMail);

            await _userOperationClaimBusinessRules.CheckifOperationClaimsExists(request.ClaimIds);

            User? getUser = await _userOperationClaimService.GetUserByEmailAsync(request.UserMail);

            IList<OperationClaim> newOperationClaimForUser = await _userOperationClaimService.GetOperationClaimsOfExistingOnesByUserAndClaimIdsAsync(getUser, request.ClaimIds);

            _userOperationClaimBusinessRules.ClaimsIsNull(newOperationClaimForUser);

            await MultipleAdd(userOperationClaimIds, getUser, newOperationClaimForUser);

            return new() { ClaimNames = OperationClaimsToOperationClaimNames(newOperationClaimForUser), Ids = userOperationClaimIds, UserMail = getUser.Email };                                                            
        }

        private async Task MultipleAdd(IList<Guid> userOperationClaimIds, User? getUser, IList<OperationClaim> newOperationClaimForUser)
        {
            foreach (OperationClaim operationClaim in newOperationClaimForUser)
            {
                UserOperationClaim newUserOperationClaim = new() { UserId = getUser.Id, OperationClaimId = operationClaim.Id };

                UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(newUserOperationClaim);

                userOperationClaimIds.Add(addedUserOperationClaim.Id);
            }
        }

        private IList<string> OperationClaimsToOperationClaimNames(IList<OperationClaim> operationClaims)
        {
            return operationClaims.Select(y => y.Name).ToList();
        }
    }
}
