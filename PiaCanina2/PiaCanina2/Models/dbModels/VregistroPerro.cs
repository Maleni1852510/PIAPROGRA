using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    [Keyless]
    public partial class VregistroPerro
    {
        [Column("IDPerro")]
        public int Idperro { get; set; }
        [StringLength(50)]
        public string NombreRaza { get; set; }
        [StringLength(10)]
        public string Edad { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Peso { get; set; }
        [Column(TypeName = "image")]
        public byte[] Foto { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        [StringLength(50)]
        public string Sexo { get; set; }
        [StringLength(50)]
        public string Tamaño { get; set; }
    }
}
