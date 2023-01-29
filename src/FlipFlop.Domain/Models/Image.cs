using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Models
{
    public class Image : BaseModel<long>
    {
        [Required]
        public string Path { get; set; } = default!;
        [Required]
        public long UploaderId { get; set; } = default!;
        [Required]
        public User Uploader { get; set; } = default!;
        [Required]
        public long PostId { get; set; } = default!;
        [Required]
        public Post Post { get; set; } = default!;
    }
}
