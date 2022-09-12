namespace Application.Features.UserGits.Dtos
{
    public class RemovedUserGitDto
    {
        public string GitAddress { get; set; }
        public bool IsSuccess { get; set; }

        public RemovedUserGitDto() { }

        public RemovedUserGitDto(string gitAddress, bool isSuccess)
        {
            GitAddress = gitAddress;
            IsSuccess = isSuccess;
        }
    }
}
