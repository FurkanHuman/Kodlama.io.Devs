namespace Application.Features.ProgrammingTechnologies.Dtos
{
    public class RemovedProgrammingTechnologyDto
    {
        public int Id { get; set; }

        public bool IsdeletedState { get; set; } = false;

        public RemovedProgrammingTechnologyDto() { }

        public RemovedProgrammingTechnologyDto(int id)
        {
            Id = id;
        }

        public RemovedProgrammingTechnologyDto(int id, bool ısdeletedState)
        {
            Id = id;
            IsdeletedState = ısdeletedState;
        }
    }
}
