using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
