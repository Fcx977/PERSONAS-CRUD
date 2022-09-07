using System;
using System.Collections.Generic;

namespace TALLERCON.Models
{
    public partial class Persona
    {
        public int DocIdentificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Credencial { get; set; }
        public int? IdRol { get; set; }
        public string? CiudadDireccion { get; set; }
        public string? CorreoNivelEstudio { get; set; }

        public virtual Role? oRol { get; set; }
    }
}
