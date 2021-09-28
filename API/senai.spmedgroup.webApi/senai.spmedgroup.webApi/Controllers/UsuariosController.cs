using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using senai.spmedgroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            if (novoUsuario.IdTipoUsuario <= 0)
            {
                return BadRequest(new
                {
                    Mensagem = "Informe todos os dados necessários"
                });
            }

            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201, new
            {
                Mensagem = "Usuario criado"
            });
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Listar()
        {
            List<Usuario> listaUsuarios = _usuarioRepository.ListarTodos();

            if (listaUsuarios == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Nenhum úsuario encontrado"
                });
            }

            return Ok(listaUsuarios);
        }
    }
}
