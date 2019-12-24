using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSite.Data
{
    public partial class Kullanicilar
    {
        public Kullanicilar()
        {
            Rezervasyonlar = new HashSet<Rezervasyonlar>();
            Roller = new HashSet<Roller>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [InverseProperty("Kullanici")]
        public virtual ICollection<Rezervasyonlar> Rezervasyonlar { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Roller> Roller { get; set; }
    }
}
