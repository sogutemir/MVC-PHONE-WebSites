using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneProg.Data.Models
{
    public class Telefonlar : BaseEntity
    {

        public string AdSoyad { get; set; }

        public string TelefonAlısFiyati { get; set; }
         
        public string TelefonNo { get; set; }

        public string Durum { get; set;} 
        
        public DateTime? EklenmeTarihi { get; set; }
   
        public string Imeil { get; set; }
        
        public string SatısFiyatı { get; set; }

        public DateTime? SatisTarihi { get; set; }

        public bool? Satildi { get; set; }

        public virtual List<Dukkanlar> Dukkanlar { get; set; }
  
        public virtual List<Kategori> Kategoriler { get; set; }

       


    }
}
