using Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.OperationClaims.Commands.RemoveOperationClaim
{
    public class RemoveOperationClaimCommand : IRequest<RemovedOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { nameof(RemoveOperationClaimCommand) };
    }
}
