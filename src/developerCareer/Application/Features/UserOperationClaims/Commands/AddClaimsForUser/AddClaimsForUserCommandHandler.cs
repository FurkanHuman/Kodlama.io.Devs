using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.AddClaimsForUser
{
    public class AddClaimsForUserCommandHandler : IRequestHandler<AddClaimsForUserCommand, AddClaimsForUserDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public AddClaimsForUserCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository, IUserRepository userRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
            _userRepository = userRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<AddClaimsForUserDto> Handle(AddClaimsForUserCommand request, CancellationToken cancellationToken)
        {
            IList<Guid> userOperationClaimIds = new List<Guid>();

            await _userOperationClaimBusinessRules.CheckIfUserMailExists(request.UserMail);

            await _userOperationClaimBusinessRules.CheckifOperationClaimsExists(request.ClaimIds);

            User getUser = await _userRepository.GetAsync(h => h.Email == request.UserMail);

            IPaginate<OperationClaim> getOperationClaimsForUser = await _operationClaimRepository.GetListAsync(o => request.ClaimIds.Contains(o.Id));

            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(k => k.UserId == getUser.Id);

            IList<OperationClaim> newOperationClaimForUser = getOperationClaimsForUser.Items.Except(userOperationClaims.Items.Select(y => y.OperationClaim)).ToList();

            _userOperationClaimBusinessRules.ClaimsIsNull(newOperationClaimForUser);

            foreach (OperationClaim OP in newOperationClaimForUser)
            {
                UserOperationClaim newUserOperationClaim = new() { UserId = getUser.Id, OperationClaimId = OP.Id };

                UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(newUserOperationClaim);

                userOperationClaimIds.Add(addedUserOperationClaim.Id);
            }

            return new() { ClaimNames = newOperationClaimForUser.Select(p => p.Name).ToList(), Ids = userOperationClaimIds, UserMail = getUser.Email };
        }
    }
}
