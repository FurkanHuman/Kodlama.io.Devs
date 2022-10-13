using Application.Features.UserOperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.AddClaimsForUser
{
    public class AddClaimsForUserCommand : IRequest<AddClaimsForUserDto>, ISecuredRequest
    {
        public string UserMail { get; set; }

        public IList<int> ClaimIds { get; set; }

        public string[] Roles => new[] { nameof(AddClaimsForUserCommand) };
    }
}
