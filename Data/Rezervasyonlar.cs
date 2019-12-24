using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSite.Data
{
    public partial class Rezervasyonlar
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("KullaniciID")]
        public int? KullaniciId { get; set; }
        [Column("OtelID")]
        public int? OtelId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BaslangicTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SonTarih { get; set; }
        public int? KisiSayisi { get; set; }

        [ForeignKey(nameof(KullaniciId))]
        [InverseProperty(nameof(Kullanicilar.Rezervasyonlar))]
        public virtual Kullanicilar Kullanici { get; set; }
        [ForeignKey(nameof(OtelId))]
        [InverseProperty(nameof(Oteller.Rezervasyonlar))]
        public virtual Oteller Otel { get; set; }
    }
}
