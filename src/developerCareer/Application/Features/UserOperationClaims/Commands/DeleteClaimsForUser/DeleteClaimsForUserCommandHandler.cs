using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteClaimsForUser
{
    public class DeleteClaimsForUserCommandHandler : IRequestHandler<DeleteClaimsForUserCommand, DeleteClaimsForUserDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public DeleteClaimsForUserCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<DeleteClaimsForUserDto> Handle(DeleteClaimsForUserCommand request, CancellationToken cancellationToken)
        {
            IList<Guid> userOperationClaimIds = new List<Guid>();

            await _userOperationClaimBusinessRules.CheckifOperationClaimsExists(request.ClaimIds);

            await _userOperationClaimBusinessRules.CheckIfUserMailExists(request.UserMail);

            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(u => request.ClaimIds.Contains(u.OperationClaimId) && u.User.Email == request.UserMail, size: int.MaxValue, cancellationToken: cancellationToken);

            _userOperationClaimBusinessRules.UserOperationClaimsNullCheck(userOperationClaims.Items);

            foreach (UserOperationClaim userOperationClaim in userOperationClaims.Items)
            {
                UserOperationClaim deletedUOC = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
                userOperationClaimIds.Add(deletedUOC.Id);
            }

            return new() { ClaimNames = userOperationClaims.Items.Select(p => p.OperationClaim.Name).ToList(), UserMail = request.UserMail };
        }
    }
}
