using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Models
{
    public class BaseModel<T>
    {
        [Key]
        public T Id { get; set; } = default!;
    }
}
