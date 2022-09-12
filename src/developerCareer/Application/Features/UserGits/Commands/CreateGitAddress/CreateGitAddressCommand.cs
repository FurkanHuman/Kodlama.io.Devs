using Application.Features.UserGits.Dtos;
using MediatR;

namespace Application.Features.UserGits.Commands.CreateGitAddress
{
    public class CreateGitAddressCommand:IRequest<CreatedUserGitDto>
    {
        public string Email { get; set; }
        public string GitAddress { get; set; }
    }
}
