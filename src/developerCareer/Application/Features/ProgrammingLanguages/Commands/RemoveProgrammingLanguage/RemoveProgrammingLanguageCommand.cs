using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.RemoveProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommand:IRequest<RemovedProgrammingLanguageDto>
    {
        public int Id { get; set; }
    }
}
