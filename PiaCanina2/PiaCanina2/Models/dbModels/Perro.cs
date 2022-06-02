using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    public partial class Perro
    {
        public Perro()
        {
            PerroVacunas = new HashSet<PerroVacuna>();
        }

        [Key]
        [Column("IDPerro")]
        public int Idperro { get; set; }
        public int Raza { get; set; }
        [Required]
        [StringLength(10)]
        public string Edad { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Peso { get; set; }
        [Column(TypeName = "image")]
        public byte[] Foto { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public bool Sexo { get; set; }
        public int Tamaño { get; set; }
        [Column("idusuario")]
        public int? Idusuario { get; set; }

        [ForeignKey(nameof(Raza))]
        [InverseProperty("Perros")]
        public virtual Raza RazaNavigation { get; set; }
        [ForeignKey(nameof(Idusuario))]
        [InverseProperty("Perros")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; }
        [ForeignKey(nameof(Tamaño))]
        [InverseProperty(nameof(Tamano.Perros))]
        public virtual Tamano TamañoNavigation { get; set; }
        [InverseProperty(nameof(PerroVacuna.IdperroNavigation))]
        public virtual ICollection<PerroVacuna> PerroVacunas { get; set; }
    }
}
