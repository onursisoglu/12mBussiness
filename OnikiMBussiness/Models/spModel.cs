using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnikiMBussiness.Models
{
    public class spModel
    {
        // Sql ' den cagırılan store procedure için döndüğü tipe uygun List yapabilmesini sağlayan model 
        public int ID { get; set; }
        public string IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public string Tarih { get; set; }
        public decimal GirisMiktar { get; set; }
        public decimal CikisMiktar { get; set; }
        [NotMapped]
        public decimal? StokMiktar { get; set; }
    }
}
