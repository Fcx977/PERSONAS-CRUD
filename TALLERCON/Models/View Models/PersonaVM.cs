using Microsoft.AspNetCore.Mvc.Rendering;

namespace TALLERCON.Models.View_Models
{
    public class PersonaVM
    {
        public Persona oPersona { get; set; }
        public List<SelectListItem> oListaRol { get; set; }

    }
}
