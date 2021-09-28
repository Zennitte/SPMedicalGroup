using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using senai.spmedgroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Consulta novaConsulta)
        {
            if (novaConsulta == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Dados da consulta invalidos ou incompletos"
                });
            }

            _consultaRepository.Cadastrar(novaConsulta);

            return StatusCode(201, new
            {
                Mensagem = "Cadastro de consulta feito"
            });
        }

        [Authorize(Roles = "2")]
        [HttpPatch("Cancelar/{id}")]
        public IActionResult Cancelar(int id)
        {
            if (id < 0 || _consultaRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Id invalido ou inexistente"
                });
            }

            _consultaRepository.Cancelar(id);

            return StatusCode(204, new
            {
                Mensagem = "Consulta cancelada"
            });
        }

        [Authorize(Roles = "1,3")]
        [HttpGet("Listar/Minhas")]
        public IActionResult ListarMinhas()
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            int idTipo = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);

            List<Consulta> listaConsultas = _consultaRepository.ListarMinhas(id, idTipo);

            if (listaConsultas.Count == 0)
            {
                return NotFound(new
                {
                    Mensagem = "Nenhuma consulta encontrada"
                });
            }

            if (idTipo == 1)
            {
                return Ok(new
                {
                    Mensagem = $"O paciente buscado tem {_consultaRepository.ListarMinhas(id, idTipo).Count} consultas",
                    listaConsultas
                });
            }

            if (idTipo == 3)
            {
                return Ok(new
                {
                    Mensagem = $"O médico buscado tem {_consultaRepository.ListarMinhas(id, idTipo).Count} consultas",
                    listaConsultas
                });
            }

            return null;
        }

        [Authorize(Roles = "3")]
        [HttpPatch("Descricao/{id}")]
        public IActionResult AlterarDescricao(Consulta consultaAtualizada, int id)
        {
            Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);
            int idMed = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            if (consultaAtualizada.Descricao == null)
            {
                return BadRequest(new
                {
                    Mensagem = "É necessário informar a descrição"
                });
            }

            if (id <= 0 || _consultaRepository.BuscarPorId(id) == null)
            {
                return NotFound(new
                {
                    Mensagem = "Id informado invalido ou inexistente"
                });
            }

            if (consultaBuscada.IdMedico != idMed)
            {
                return Unauthorized(new
                {
                    Mensagem = "Somente o médico titular pode alterar a descrição dessa consulta"
                });
            }

            _consultaRepository.AlterarDescricao(consultaAtualizada.Descricao, id);

            return Ok(new
            {
                Mensagem = "Descrição da consulta alterada com sucesso",
                consultaAtualizada
            }); 
        }
    }
}
