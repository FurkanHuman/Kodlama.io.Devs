using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Users.Queries.GetByEmailUserForClaims
{
    public class GetByEmailUserForClaimsQuery : IRequest<GetByEmailUserForClaimsDto>, ISecuredRequest
    {
        public string Email { get; set; }

        public string[] Roles => new[] { nameof(GetByEmailUserForClaimsQuery) };
    }
}
