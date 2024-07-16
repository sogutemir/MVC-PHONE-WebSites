using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhoneProg.Data.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
