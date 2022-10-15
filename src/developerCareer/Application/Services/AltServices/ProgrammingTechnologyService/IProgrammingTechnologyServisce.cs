using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AltServices.ProgrammingTechnologyService
{
    public interface IProgrammingTechnologyService
    {
        Task<ProgrammingLanguage?> GetProgrammingLanguageById(int programmingLanguageId);
    }
}
