using Application.Features.UserGits.Dtos;
using MediatR;

namespace Application.Features.UserGits.Commands.RemoveGitAddress
{
    public class RemoveGitAddressCommand : IRequest<RemovedUserGitDto>
    {
        public string Email { get; set; }
    }

}
