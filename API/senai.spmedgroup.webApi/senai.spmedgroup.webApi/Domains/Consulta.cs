using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "Id do Paciente necessário")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "Id do Médico necessário")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "Id da Situação necessário")]
        public byte? IdSituacao { get; set; }

        [Required(ErrorMessage = "Descrição necessário")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data da Consulta necessária")]
        public DateTime DataConsul { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
