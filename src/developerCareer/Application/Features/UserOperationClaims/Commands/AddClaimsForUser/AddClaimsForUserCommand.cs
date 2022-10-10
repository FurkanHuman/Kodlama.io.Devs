using Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.AddClaimsForUser
{
    public class AddClaimsForUserCommand : IRequest<AddClaimsForUserDto>
    {
        public string UserMail { get; set; }

        public IList<int> ClaimIds { get; set; }
    }
}
