using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepo;
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepo;

        public ProgrammingTechnologyBusinessRules(IProgrammingLanguageRepository programmingLanguageRepo, IProgrammingTechnologyRepository programmingTechnologyRepo)
        {
            _programmingLanguageRepo = programmingLanguageRepo;
            _programmingTechnologyRepo = programmingTechnologyRepo;
        }

        public async Task ProgrammingLanguageNullCheckById(int programmingLanguageId)
        {
            ProgrammingLanguage? result = await _programmingLanguageRepo.GetAsync(pl => pl.Id == programmingLanguageId);
            if (result == null) throw new BusinessException("Programming Language is Null.");
        }

        public async Task ProgrammingTechnologyAddingBeforeDataBaseControlByName(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepo.GetListAsync(pl => pl.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException("Programming Technology is Exit.");
        }

        public void ProgrammingTechnologyNullCheck(ProgrammingTechnology? programmingTechnology)
        {
            if (programmingTechnology == null) throw new BusinessException("Programming Technology is Null.");
        }
    }
}
