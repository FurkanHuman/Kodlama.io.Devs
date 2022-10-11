
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
            await _userOperationClaimBusinessRules.CheckifOperationClaimExists(request.ClaimId);

            await _userOperationClaimBusinessRules.CheckIfUserMailExists(request.UserMail);

            UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(u => u.OperationClaimId == request.ClaimId && u.User.Email == request.UserMail);

            return new() { ClaimName = deletedUserOperationClaim.OperationClaim.Name, UserMail = deletedUserOperationClaim.User.Email };
        }
    }
}
