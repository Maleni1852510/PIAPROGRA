using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    public partial class Vacuna
    {
        public Vacuna()
        {
            PerroVacunas = new HashSet<PerroVacuna>();
        }

        [Key]
        [Column("IDVacuna")]
        public int Idvacuna { get; set; }
        [StringLength(50)]
        public string NombreVacuna { get; set; }

        [InverseProperty(nameof(PerroVacuna.IdvacunaNavigation))]
        public virtual ICollection<PerroVacuna> PerroVacunas { get; set; }
    }
}
