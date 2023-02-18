using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Models
{
    public class Image : BaseModel<string>
    {
        [Required]
        public string Path { get; set; } = default!;
        [Required]
        public string UploaderId { get; set; } = default!;
        [Required]
        public User Uploader { get; set; } = default!;
        [Required]
        public string PostId { get; set; } = default!;
        [Required]
        public Post Post { get; set; } = default!;
    }
}
