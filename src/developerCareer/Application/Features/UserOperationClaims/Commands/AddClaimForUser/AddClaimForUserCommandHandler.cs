using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.AltServices.UserOperationClaimService;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.AddClaimForUser
{
    public class AddClaimForUserCommandHandler : IRequestHandler<AddClaimForUserCommand, AddClaimForUserDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public AddClaimForUserCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IUserOperationClaimService userOperationClaimService, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimService = userOperationClaimService;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<AddClaimForUserDto> Handle(AddClaimForUserCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.CheckIfUserMailExists(request.UserMail);
            await _userOperationClaimBusinessRules.CheckifOperationClaimExists(request.ClaimId);

            User? getUser = await _userOperationClaimService.GetUserByEmailAsync(request.UserMail);

            await _userOperationClaimBusinessRules.CheckifUserOperationClaimExists(getUser, request.ClaimId);

            UserOperationClaim addedUPC = _userOperationClaimRepository.Add(new() { OperationClaimId = request.ClaimId, UserId = getUser.Id });

            return new() { Id = addedUPC.Id, ClaimName = addedUPC.OperationClaim.Name, UserMail = getUser.Email };
        }
    }
}
