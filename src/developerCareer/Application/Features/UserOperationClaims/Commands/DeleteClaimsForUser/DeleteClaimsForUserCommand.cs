using Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteClaimsForUser
{
    public class DeleteClaimsForUserCommand : IRequest<DeleteClaimsForUserDto>
    {
        public string UserMail { get; set; }

        public IList<int> ClaimIds { get; set; }
    }
}
