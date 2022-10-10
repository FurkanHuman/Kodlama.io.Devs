using Application.Features.ProgrammingTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetListProgrammingTechnologyQuery, ProgrammingTechnologyListModel>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingTechnology> paginate = await _programmingTechnologyRepository.GetListAsync(include: i => i.Include(pl => pl.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            return _mapper.Map<ProgrammingTechnologyListModel>(paginate);
        }
    }
}
