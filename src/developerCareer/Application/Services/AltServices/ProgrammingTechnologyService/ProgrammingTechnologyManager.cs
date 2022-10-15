using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.AltServices.ProgrammingTechnologyService
{
    public class ProgrammingTechnologyManager : IProgrammingTechnologyService
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingTechnologyManager(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<ProgrammingLanguage?> GetProgrammingLanguageById(int programmingLanguageId)
        {
           return await _programmingLanguageRepository.GetAsync(p => p.Id == programmingLanguageId);
        }
    }
}
