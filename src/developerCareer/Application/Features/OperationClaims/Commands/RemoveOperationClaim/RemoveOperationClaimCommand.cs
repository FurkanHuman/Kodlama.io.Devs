using Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Application.Features.OperationClaims.Commands.RemoveOperationClaim
{
    public class RemoveOperationClaimCommand : IRequest<RemovedOperationClaimDto>
    {
        public int Id { get; set; }
    }
}
