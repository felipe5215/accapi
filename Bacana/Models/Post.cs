using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bacana.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "content is required")]
        [MaxLength(125, ErrorMessage = "content can't be longer than 125 characters")]
        public string? Content { get; set; }

        [StringLength(120)]
        public string? Image { get; set; }

        [Required(ErrorMessage = "id is required")]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
