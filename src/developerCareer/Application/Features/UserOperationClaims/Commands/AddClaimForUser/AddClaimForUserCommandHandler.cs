using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.AddClaimForUser
{
    public class AddClaimForUserCommandHandler : IRequestHandler<AddClaimForUserCommand, AddClaimForUserDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public AddClaimForUserCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<AddClaimForUserDto> Handle(AddClaimForUserCommand request, CancellationToken cancellationToken)
        {
            User validatedUser = await _userOperationClaimBusinessRules.CheckIfUserMailExists(request.UserMail);
            OperationClaim validatedClaim = await _userOperationClaimBusinessRules.CheckifOperationClaimExists(request.ClaimId);

            UserOperationClaim addedUPC = _userOperationClaimRepository.Add(new() { OperationClaimId = validatedClaim.Id, UserId = validatedUser.Id });

            return new() { Id = addedUPC.Id, ClaimName = validatedClaim.Name, UserMail = validatedUser.Email };
        }
    }
}
