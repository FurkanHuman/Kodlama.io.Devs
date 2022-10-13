using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AltServices.UserService
{
    public class UserManager : IUserService
    {

        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserManager(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }
        public async Task<IList<string>> GetByUserForUserOperationClaimsAsync(User? user)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(y => y.User == user, include: y => y.Include(k => k.OperationClaim), size: int.MaxValue);

            return userOperationClaims.Items.Select(o => o.OperationClaim.Name).ToList();
        }
    }
}
