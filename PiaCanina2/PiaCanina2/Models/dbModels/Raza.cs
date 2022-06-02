using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    [Table("Raza")]
    public partial class Raza
    {
        public Raza()
        {
            Perros = new HashSet<Perro>();
        }

        [Key]
        [Column("IDRaza")]
        public int Idraza { get; set; }
        [StringLength(50)]
        public string NombreRaza { get; set; }

        [InverseProperty(nameof(Perro.RazaNavigation))]
        public virtual ICollection<Perro> Perros { get; set; }
    }
}
