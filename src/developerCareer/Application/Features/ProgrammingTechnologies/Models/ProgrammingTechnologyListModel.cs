using Application.Features.ProgrammingTechnologies.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingTechnologies.Models
{
    public class ProgrammingTechnologyListModel : BasePageableModel
    {
        public IList<ProgrammingTechnologyListDto> Items { get; set; }
    }
}
