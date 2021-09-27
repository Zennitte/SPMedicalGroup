using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }

        [Required(ErrorMessage = "Nome Fantasia necessário")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "CNPJ necessário")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Razão Social necessária")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Endereço necessário")]
        public string Endereco { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
