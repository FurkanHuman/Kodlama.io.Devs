using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.RemoveProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommandValidator : AbstractValidator<RemoveProgrammingLanguageCommand>
    {
        public RemoveProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.Id).NotNull().NotEmpty();
        }
    }
}
