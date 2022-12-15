using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bacana.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "name is required")]
        [StringLength(80)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "email is required")]
        [StringLength(400)]
        public string? Email { get; set; }

        [StringLength(300)]
        public string? IsActive { get; set; }

        [Required(ErrorMessage = "password is required")]
        [StringLength(80)]
        public string? Password { get; set; }

        [StringLength(300)]
        [JsonIgnore]
        public ICollection<Post>? Post { get; set; }
    }
}
