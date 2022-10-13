using Application.Features.UserGits.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserGits.Commands.RemoveGitAddress
{
    public class RemoveGitAddressCommand : IRequest<RemovedUserGitDto>, ISecuredRequest
    {
        public string Email { get; set; }

        public string[] Roles => new[] { nameof(RemoveGitAddressCommand) };
    }

}
