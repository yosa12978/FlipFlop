using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Models
{
    public class Comment : BaseModel<long>
    {
        [Required]
        public long PostId { get; set; }
        [Required]
        public string Body { get; set; } = default!;
        [Required]
        public long AuthorId { get; set; }
        [Required]
        public User Author { get; set; } = default!;
    }
}
