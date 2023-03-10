using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Models
{
    public class User : BaseModel<string>
    {
        [Required]
        public string Username { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public string Salt { get; set; } = default!;
        public string Role { get; set; } = Roles.USER;
    }
}
