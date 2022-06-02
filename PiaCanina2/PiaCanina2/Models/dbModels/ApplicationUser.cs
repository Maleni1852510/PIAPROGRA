using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//Tabla de empleados

namespace PiaCanina2.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Perros = new HashSet<Perro>();
        }

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [InverseProperty(nameof(Perro.IdUsuarioNavigation))]

        public virtual ICollection<Perro> Perros { get; set; }
    }
}
