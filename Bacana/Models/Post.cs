using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bacana.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "text is required")]
        [MaxLength(125, ErrorMessage = "max length is 125 chars")]
        public string? Description { get; set; }

        [StringLength(300)]
        public string? Image { get; set; }

        [Required(ErrorMessage = "required id")]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
