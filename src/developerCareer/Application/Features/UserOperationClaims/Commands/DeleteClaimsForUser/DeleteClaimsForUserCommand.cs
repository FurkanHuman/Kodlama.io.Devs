using Application.Features.UserOperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteClaimsForUser
{
    public class DeleteClaimsForUserCommand : IRequest<DeleteClaimsForUserDto>, ISecuredRequest
    {
        public string UserMail { get; set; }

        public IList<int> ClaimIds { get; set; }

        public string[] Roles => new[] { nameof(DeleteClaimsForUserCommand) };
    }
}
