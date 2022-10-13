using Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<OperationClaimGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { nameof(GetByIdOperationClaimQuery) };
    }
}
