using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetByEmailUserForClaims
{
    public class GetByEmailUserForClaimsQueryHandler : IRequestHandler<GetByEmailUserForClaimsQuery, GetByEmailUserForClaimsDto>
    {
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public GetByEmailUserForClaimsQueryHandler(UserBusinessRules userBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userBusinessRules = userBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<GetByEmailUserForClaimsDto> Handle(GetByEmailUserForClaimsQuery request, CancellationToken cancellationToken)
        {
            User getUser = await _userBusinessRules.UserExistByMailAddress(request.Email);

            IList<string> OperationClaims = _userOperationClaimRepository.GetListAsync(y => y.UserId == getUser.Id, include: y => y.Include(k => k.OperationClaim), size: int.MaxValue).Result.Items.Select(u => u.OperationClaim.Name).ToList();

            return new() { ClaimsName = OperationClaims, Email = getUser.Email, FirstName = getUser.FirstName, LastName = getUser.LastName };
        }
    }
}
