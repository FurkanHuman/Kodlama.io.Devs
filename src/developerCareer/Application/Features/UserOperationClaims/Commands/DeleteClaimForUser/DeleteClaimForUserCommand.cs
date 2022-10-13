
using Application.Features.UserOperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteClaimForUser
{
    public class DeleteClaimForUserCommand : IRequest<DeleteClaimForUserDto>, ISecuredRequest
    {
        public string UserMail { get; set; }

        public int ClaimId { get; set; }

        public string[] Roles => new[] { nameof(DeleteClaimForUserCommand) };
    }
}
