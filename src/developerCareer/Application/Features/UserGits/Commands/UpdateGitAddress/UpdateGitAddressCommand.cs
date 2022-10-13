using Application.Features.UserGits.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserGits.Commands.UpdateGitAddress
{
    public class UpdateGitAddressCommand : IRequest<UpdatedUserGitDto>, ISecuredRequest
    {
        public string Email { get; set; }
        public string GitAddress { get; set; }

        public string[] Roles => new[] { nameof(UpdateGitAddressCommand) };
    }
}
