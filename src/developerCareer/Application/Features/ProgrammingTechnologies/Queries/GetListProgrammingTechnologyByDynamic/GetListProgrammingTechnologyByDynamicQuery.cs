using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingTechnologies.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic
{
    public class GetListProgrammingTechnologyByDynamicQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }
    }
}
