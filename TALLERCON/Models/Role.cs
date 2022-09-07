using System;
using System.Collections.Generic;

namespace TALLERCON.Models
{
    public partial class Role
    {
        public Role()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdRol { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
