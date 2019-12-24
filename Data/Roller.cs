using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSite.Data
{
    public partial class Roller
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Column("RoleID")]
        public int? RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Kullanicilar.Roller))]
        public virtual Kullanicilar User { get; set; }
    }
}
