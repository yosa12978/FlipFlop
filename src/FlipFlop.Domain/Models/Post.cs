using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Models
{
    public class Post : BaseModel<long>
    {
        [Required]
        public string Title { get; set; } = default!;
        public string Body { get; set; } = default!;
        public List<Image> Images { get; set; } = default!;
        public long AuthorId { get; set; } = default!;
        public User Author { get; set; } = default!;
        public bool NSFW { get; set; } = false;
    }
}
