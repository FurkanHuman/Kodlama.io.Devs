namespace Application.Features.UserGits.Dtos
{
    public class UpdatedUserGitDto
    {
        public string GitAddress { get; set; }
        public bool IsSuccess { get; set; }

        public UpdatedUserGitDto() { }


        public UpdatedUserGitDto(string gitAddress, bool isSuccess)
        {
            GitAddress = gitAddress;
            IsSuccess = isSuccess;
        }
    }
}
