using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Rules
{

    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageService;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageService)
        {
            _programmingLanguageService = programmingLanguageService;
        }

        public async Task ProgrammingLanguageAddingBeforeDataBaseControlByName(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageService.GetListAsync(pl => pl.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException("Programming Language is Exit.");
        }

        public void ProgrammingLanguageNullCheck(ProgrammingLanguage? getPl)
        {
            if (getPl == null) throw new BusinessException("Programming Language is Null.");
        }
    }
}
