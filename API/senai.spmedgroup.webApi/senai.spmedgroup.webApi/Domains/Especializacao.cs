using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Especializacao
    {
        public Especializacao()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte IdEspecializacao { get; set; }
        public string NomeEspec { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
