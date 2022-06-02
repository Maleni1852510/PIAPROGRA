using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    [Table("Tamano")]
    public partial class Tamano
    {
        public Tamano()
        {
            Perros = new HashSet<Perro>();
        }

        [Key]
        public int IdTamano { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(Perro.TamañoNavigation))]
        public virtual ICollection<Perro> Perros { get; set; }
    }
}
