using Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<OperationClaimGetByIdDto>
    {
        public int Id { get; set; }
    }
}
