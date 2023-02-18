using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Models
{
    public class Comment : BaseModel<string>
    {
        [Required]
        public string PostId { get; set; } = default!;
        [Required]
        public string Body { get; set; } = default!;
        [Required]
        public string AuthorId { get; set; } = default!;
        [Required]
        public User Author { get; set; } = default!;
    }
}
