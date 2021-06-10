using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.web.Models
{
    public class PacienteModel
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        [Display(Name = "Identificador del Cliente")]
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(128)]
        [MinLength(3)]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }
        public bool Estado { get; set; }
    }
}
