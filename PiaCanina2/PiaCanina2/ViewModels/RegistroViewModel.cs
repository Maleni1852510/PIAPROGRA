using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiaCanina2.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Raza:")]
        public int Raza { get; set; }
        public List<SelectListItem> RazaPerros { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Edad:")]
        public string Edad { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Peso:")]
        public decimal Peso { get; set; }
        [DisplayName("Sexo:")]
        public bool Sexo { get; set; }

        /*  [DisplayName("Tamaño:")]
         public string Tamaño { get; set; }*/

        [DisplayName("Descripcion:")]
        public string Descripcion { get; set; }
        [DisplayName("Foto:")]
        public IFormFile Foto { get; set; }

    }
}
