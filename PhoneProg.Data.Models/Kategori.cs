using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace PhoneProg.Data.Models
{
    public class Kategori : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Ad { get; set; }
        public virtual List<Telefonlar> Telefonlar { get; set; }

    }
}
