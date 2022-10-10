namespace Application.Features.Users.Dtos
{
    public class GetByEmailUserForClaimsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IList<string> ClaimsName { get; set; }
    }
}
