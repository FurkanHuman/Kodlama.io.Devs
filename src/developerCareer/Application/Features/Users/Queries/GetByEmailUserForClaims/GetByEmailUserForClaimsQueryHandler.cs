using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AltServices.UserService;
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
        private readonly IUserService _userService;
        public GetByEmailUserForClaimsQueryHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IUserService userService)
        {
            _userBusinessRules = userBusinessRules;
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<GetByEmailUserForClaimsDto> Handle(GetByEmailUserForClaimsQuery request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserExistByMailAddress(request.Email);

            User? getUser = await _userRepository.GetAsync(u => u.Email == request.Email);

            return new() { ClaimsName = await _userService.GetByUserForUserOperationClaimsAsync(getUser), Email = getUser.Email, FirstName = getUser.FirstName, LastName = getUser.LastName };
        }
    }
}
