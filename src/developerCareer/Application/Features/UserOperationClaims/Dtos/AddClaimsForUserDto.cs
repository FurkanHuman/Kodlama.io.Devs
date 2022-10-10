namespace Application.Features.UserOperationClaims.Dtos
{
    public class AddClaimsForUserDto
    {
        public IList<Guid> Ids { get; set; }

        public string UserMail { get; set; }

        public IList<string> ClaimNames { get; set; }
    }
}
