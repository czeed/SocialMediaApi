using System.ComponentModel.DataAnnotations;

namespace CwkSocial.Api.Contracts.UserProfile.Requests
{
    public record UserProfileUpdate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(55)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MinLength(3)]
        [MaxLength(55)]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        [Required]  
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DayOfBirth { get; set; }
        public string CurrentCity { get; set; } = string.Empty;
    }
}
