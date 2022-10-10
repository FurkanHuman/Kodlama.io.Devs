using Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.AddClaimForUser
{
    public class AddClaimForUserCommand : IRequest<AddClaimForUserDto>
    {
        public string UserMail { get; set; }

        public int ClaimId { get; set; }
    }
}
