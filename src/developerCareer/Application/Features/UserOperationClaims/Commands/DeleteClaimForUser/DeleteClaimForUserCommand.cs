
using Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteClaimForUser
{
    public class DeleteClaimForUserCommand : IRequest<DeleteClaimForUserDto>
    {
        public string UserMail { get; set; }

        public int ClaimId { get; set; }
    }
}
