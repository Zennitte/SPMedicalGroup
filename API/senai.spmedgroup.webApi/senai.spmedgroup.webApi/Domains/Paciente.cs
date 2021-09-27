using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consultas = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Data de nascimento necessária")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Telefone necessário")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "RG necessário")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "CPF necessário")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Endereço necessário")]
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
