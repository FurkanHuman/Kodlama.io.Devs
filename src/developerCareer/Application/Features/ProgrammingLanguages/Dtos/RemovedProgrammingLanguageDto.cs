namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class RemovedProgrammingLanguageDto
    {
        public int Id { get; set; }

        public bool IsdeletedState { get; set; } = false;

        public RemovedProgrammingLanguageDto() { }

        public RemovedProgrammingLanguageDto(int ıd)
        {
            Id = ıd;
        }

        public RemovedProgrammingLanguageDto(int ıd, bool ısdeletedState)
        {
            Id = ıd;
            IsdeletedState = ısdeletedState;
        }
    }
}