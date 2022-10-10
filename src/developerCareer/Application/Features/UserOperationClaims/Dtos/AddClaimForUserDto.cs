namespace Application.Features.UserOperationClaims.Dtos
{
    public class AddClaimForUserDto
    {
        public Guid Id { get; set; }

        public string UserMail { get; set; }

        public string ClaimName { get; set; }
    }
}
