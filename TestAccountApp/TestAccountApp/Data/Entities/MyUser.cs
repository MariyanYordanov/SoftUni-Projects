using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TestAccountApp.Data.Entities
{
    public class MyUser : IdentityUser
    {
        [Key]
        public int MyUserId { get; set; }

        [Required]
        [MaxLength(15)]
        public string FirstName { get; init; } = null!;

        [Required]
        [MaxLength(15)]
        public string LastName { get; init; } = null!;
    }
}
