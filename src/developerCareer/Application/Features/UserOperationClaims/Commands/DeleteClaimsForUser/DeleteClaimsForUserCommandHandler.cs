using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using FluentValidation.Results;
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

            IList<UserOperationClaim> userOperationClaims = await _userOperationClaimBusinessRules.CheckifUserOperationClaimExistsByMailAndClaimIds(request.UserMail, request.ClaimIds);

            foreach (UserOperationClaim userOperationClaim in userOperationClaims)
            {
                UserOperationClaim deletedUOC = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
                userOperationClaimIds.Add(deletedUOC.Id);
            }


            return new() { ClaimNames = userOperationClaims.Select(p => p.OperationClaim.Name).ToList(), UserMail = request.UserMail };
        }
    }
}
