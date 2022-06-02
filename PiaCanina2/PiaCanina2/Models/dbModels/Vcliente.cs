using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    [Keyless]
    public partial class Vcliente
    {
        [Column("IDPerro")]
        public int Idperro { get; set; }
        public int Raza { get; set; }
        [StringLength(50)]
        public string NombreRaza { get; set; }
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
        [Required]
        [StringLength(50)]
        public string TamanoNombre { get; set; }
        [Column("idusuario")]
        public int? Idusuario { get; set; }
    }
}
