using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneProg.Data.Models
{
    public class Uyeler : BaseEntity
    {

        
        public string Ad { get; set; }
        public string Soyad { get; set; }
       
        public string TelNo { get; set; }
      
        
        public string Mail { get; set; }
        
        
        public string Sifre { get; set; }
        
        
        public string Yetki { get; set; }   


    }
}
