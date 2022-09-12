using Application.Features.UserGits.Dtos;
using MediatR;

namespace Application.Features.UserGits.Commands.UpdateGitAddress
{
    public class UpdateGitAddressCommand : IRequest<UpdatedUserGitDto>
    {
        public string Email { get; set; }
        public string GitAddress { get; set; }
    }
}
