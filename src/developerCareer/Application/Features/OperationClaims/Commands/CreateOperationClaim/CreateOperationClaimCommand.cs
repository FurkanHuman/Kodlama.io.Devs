using Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { nameof(CreateOperationClaimCommand) };
    }
}
