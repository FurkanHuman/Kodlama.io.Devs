using Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles => new[] { nameof(UpdateOperationClaimCommand) };
    }
}
