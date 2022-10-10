
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteClaimForUser
{
    public class DeleteClaimForUserCommandHandler : IRequestHandler<DeleteClaimForUserCommand, DeleteClaimForUserDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public DeleteClaimForUserCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<DeleteClaimForUserDto> Handle(DeleteClaimForUserCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim getUserOperationClaim = await _userOperationClaimBusinessRules.CheckifUserOperationClaimExistsByMailAndClaimId(request.UserMail, request.ClaimId);

            await _userOperationClaimRepository.DeleteAsync(getUserOperationClaim);

            return new() { ClaimName = getUserOperationClaim.OperationClaim.Name, UserMail = getUserOperationClaim.User.Email };
        }
    }
}
