using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consultas = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Id de Especialização necessário")]
        public byte? IdEspecializacao { get; set; }

        [Required(ErrorMessage = "Id de Clinica necessário")]
        public short? IdClinica { get; set; }

        [Required(ErrorMessage = "CRM necessária")]
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especializacao IdEspecializacaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
