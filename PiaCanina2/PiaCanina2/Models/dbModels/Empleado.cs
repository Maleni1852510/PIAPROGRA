using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    [Table("Empleado")]
    public partial class Empleado
    {
        [Key]
        [Column("IDEmplado")]
        public int Idemplado { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(70)]
        public string Apellidos { get; set; }
        [StringLength(70)]
        public string Direccion { get; set; }
        [StringLength(50)]
        public string Usuario { get; set; }
        public int Contraseña { get; set; }
    }
}
