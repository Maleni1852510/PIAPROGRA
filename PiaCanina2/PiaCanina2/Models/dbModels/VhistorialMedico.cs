using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PiaCanina2.Models.dbModels
{
    [Keyless]
    public partial class VhistorialMedico
    {
        [Column("IDPerro")]
        public int Idperro { get; set; }
        [Column("IDVacuna")]
        public int Idvacuna { get; set; }
        [StringLength(50)]
        public string NombreVacuna { get; set; }
    }
}
