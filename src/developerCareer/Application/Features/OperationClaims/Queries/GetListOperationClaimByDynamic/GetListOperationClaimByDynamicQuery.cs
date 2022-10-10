using Application.Features.OperationClaims.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimByDynamicQuery : IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        public Dynamic Dynamic { get; set; }
    }
}
