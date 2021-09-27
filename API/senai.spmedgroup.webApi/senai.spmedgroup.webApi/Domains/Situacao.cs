using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consultas = new HashSet<Consulta>();
        }

        public byte IdSituacao { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
