using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetByEmailUserForClaims
{
    public class GetByEmailUserForClaimsQueryHandler : IRequestHandler<GetByEmailUserForClaimsQuery, GetByEmailUserForClaimsDto>
    {
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public GetByEmailUserForClaimsQueryHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userBusinessRules = userBusinessRules;
            _userRepository = userRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<GetByEmailUserForClaimsDto> Handle(GetByEmailUserForClaimsQuery request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserExistByMailAddress(request.Email);

            User? getUser = await _userRepository.GetAsync(u => u.Email == request.Email);

            IPaginate<UserOperationClaim> operationClaims = await _userOperationClaimRepository.GetListAsync(y => y.User.Email == request.Email, include: y => y.Include(k => k.OperationClaim), size: int.MaxValue);

            return new() { ClaimsName = operationClaims.Items.Select(j => j.OperationClaim.Name).ToList(), Email = getUser.Email, FirstName = getUser.FirstName, LastName = getUser.LastName };
        }
    }
}
