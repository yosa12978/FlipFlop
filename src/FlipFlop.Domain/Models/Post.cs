using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Models
{
    public class Post : BaseModel<string>
    {
        [Required]
        public string Title { get; set; } = default!;
        public string Body { get; set; } = default!;
        public List<Image> Images { get; set; } = default!;
        [Required]
        public string AuthorId { get; set; } = default!;
        [Required]
        public int CommentCount { get; set; } = default!;
        [Required]
        public DateTime PubDate { get; set; } = DateTime.UtcNow;
        [Required]
        public User Author { get; set; } = default!;
        [Required]
        public bool NSFW { get; set; } = false;
    }
}
