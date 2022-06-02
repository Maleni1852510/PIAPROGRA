using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    [Table("Perro_Raza")]
    public partial class PerroRaza
    {
        [Key]
        [Column("IDPerro")]
        public int Idperro { get; set; }
        [Key]
        [Column("IDRaza")]
        public int Idraza { get; set; }
    }
}
