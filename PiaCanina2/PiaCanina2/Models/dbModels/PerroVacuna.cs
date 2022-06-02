using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    [Table("PerroVacuna")]
    public partial class PerroVacuna
    {
        [Key]
        [Column("IDPerro")]
        public int Idperro { get; set; }
        [Key]
        [Column("IDVacuna")]
        public int Idvacuna { get; set; }

        [ForeignKey(nameof(Idperro))]
        [InverseProperty(nameof(Perro.PerroVacunas))]
        public virtual Perro IdperroNavigation { get; set; }
        [ForeignKey(nameof(Idvacuna))]
        [InverseProperty(nameof(Vacuna.PerroVacunas))]
        public virtual Vacuna IdvacunaNavigation { get; set; }
    }
}
