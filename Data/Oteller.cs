using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSite.Data
{
    public partial class Oteller
    {
        public Oteller()
        {
            Rezervasyonlar = new HashSet<Rezervasyonlar>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string OtelAdi { get; set; }
        public string Resim { get; set; }

        [InverseProperty("Otel")]
        public virtual ICollection<Rezervasyonlar> Rezervasyonlar { get; set; }
    }
}
