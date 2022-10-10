using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Queries.GetByEmailUserForClaims
{
    public class GetByEmailUserForClaimsQuery : IRequest<GetByEmailUserForClaimsDto>
    {
        public string Email { get; set; }
    }
}
