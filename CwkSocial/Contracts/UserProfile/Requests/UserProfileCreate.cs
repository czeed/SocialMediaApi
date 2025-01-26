namespace CwkSocial.Api.Contracts.UserProfile.Requests
{
    public record UserProfileCreate
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DayOfBirth { get; set; }
        public string CurrentCity { get; set; } = string.Empty;
    }
}
