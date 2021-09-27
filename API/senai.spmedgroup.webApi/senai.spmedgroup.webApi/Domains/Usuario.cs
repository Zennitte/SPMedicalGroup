using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            ImagemUsuarios = new HashSet<ImagemUsuario>();
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Nome necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email necessário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha necessário")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<ImagemUsuario> ImagemUsuarios { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
