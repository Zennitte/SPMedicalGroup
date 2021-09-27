using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Email do úsuario")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha do úsuario")]
        public string Senha { get; set; }
    }
}
