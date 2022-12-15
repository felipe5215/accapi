using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bacana.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "content is required")]
        [MaxLength(150, ErrorMessage = "content can't be longer than 150 characters")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "userId is required")]
        public int UserId { get; set; }

        //  Aula 47:
        [JsonIgnore]
        public User? User { get; set; }
    }
}
