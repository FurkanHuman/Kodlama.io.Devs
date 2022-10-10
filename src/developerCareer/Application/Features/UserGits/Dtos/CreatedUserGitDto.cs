namespace Application.Features.UserGits.Dtos
{
    public class CreatedUserGitDto
    {
        public string Email { get; set; }
        public string GitAddress { get; set; }
        public bool IsSuccess { get; set; }

        public CreatedUserGitDto() { }

        public CreatedUserGitDto(string email, string gitAddress, bool isSuccess)
        {
            Email = email;
            GitAddress = gitAddress;
            IsSuccess = isSuccess;
        }
    }
}
