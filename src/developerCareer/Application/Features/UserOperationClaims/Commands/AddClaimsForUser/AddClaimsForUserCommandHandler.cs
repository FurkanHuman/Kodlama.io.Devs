using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.AddClaimsForUser
{
    public class AddClaimsForUserCommandHandler : IRequestHandler<AddClaimsForUserCommand, AddClaimsForUserDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public AddClaimsForUserCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<AddClaimsForUserDto> Handle(AddClaimsForUserCommand request, CancellationToken cancellationToken)
        {
            IList<Guid> userOperationClaimIds = new List<Guid>();

            User validatedUser = await _userOperationClaimBusinessRules.CheckIfUserMailExists(request.UserMail);

            IList<OperationClaim> validatedOP = _userOperationClaimBusinessRules.CheckifOperationClaimsExists(request.ClaimIds);

            foreach (OperationClaim OP in validatedOP)
            {
                UserOperationClaim newUserOperationClaim = new() { UserId = validatedUser.Id, OperationClaimId = OP.Id };

                UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(newUserOperationClaim);

                userOperationClaimIds.Add(addedUserOperationClaim.Id);
            }

            return new() { ClaimNames = validatedOP.Select(p => p.Name).ToList(), Ids = userOperationClaimIds, UserMail = validatedUser.Email };
        }
    }
}
