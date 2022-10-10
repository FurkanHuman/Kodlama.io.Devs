namespace Application.Features.UserOperationClaims.Dtos
{
    public class DeleteClaimsForUserDto
    {
        public string UserMail { get; set; }

        public IList<string> ClaimNames { get; set; }
    }
}
