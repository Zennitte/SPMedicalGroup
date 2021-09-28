using Microsoft.EntityFrameworkCore;
using senai.spmedgroup.webApi.Contexts;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedGroupContext ctx = new();
        public void AlterarDescricao(string novaDescricao, int id)
        {
            Consulta consultaBuscada = BuscarPorId(id);

            consultaBuscada.Descricao = novaDescricao;

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            novaConsulta.IdSituacao = 1;

            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Cancelar(int id)
        {
            Consulta consultaBuscada = BuscarPorId(id);

            consultaBuscada.IdSituacao = 2;
            consultaBuscada.Descricao = "Consulta cancelada";

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Consultas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Consulta> ListarMinhas(int id, int idTipo)
        {
            if (idTipo == 3)
            {
                Medico medicoBuscado = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == id);

                int idMedico = medicoBuscado.IdMedico;

                return ctx.Consultas.Where(m => m.IdMedico == idMedico)
                    .Select(p => new Consulta()
                    {
                        DataConsul = p.DataConsul,
                        IdConsulta = p.IdConsulta,
                        Descricao = p.Descricao,
                        IdMedicoNavigation = new Medico()
                        {
                            Crm = p.IdMedicoNavigation.Crm,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdMedicoNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdPacienteNavigation = new Paciente()
                        {
                            Cpf = p.IdPacienteNavigation.Cpf,
                            Telefone = p.IdPacienteNavigation.Telefone,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdSituacaoNavigation = new Situacao
                        {
                            Descricao = p.IdSituacaoNavigation.Descricao
                        }
                    })
                    .ToList();
            }
            else if (idTipo == 1)
            {
                Paciente pacienteBuscado = ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);

                int idPaciente = pacienteBuscado.IdPaciente;

                return ctx.Consultas.Where(m => m.IdPaciente == idPaciente)
                    .Select(p => new Consulta()
                    {
                        DataConsul = p.DataConsul,
                        IdConsulta = p.IdConsulta,
                        IdMedicoNavigation = new Medico()
                        {
                            Crm = p.IdMedicoNavigation.Crm,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdMedicoNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdPacienteNavigation = new Paciente()
                        {
                            Cpf = p.IdPacienteNavigation.Cpf,
                            Telefone = p.IdPacienteNavigation.Telefone,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdSituacaoNavigation = new Situacao
                        {
                            Descricao = p.IdSituacaoNavigation.Descricao
                        }
                    })
                    .ToList();
            }

            return null;
        }

        public List<Consulta> ListarTodos()
        {
            return ctx.Consultas
                    .Select(p => new Consulta()
                    {
                        DataConsul = p.DataConsul,
                        IdConsulta = p.IdConsulta,
                        IdMedicoNavigation = new Medico()
                        {
                            Crm = p.IdMedicoNavigation.Crm,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdMedicoNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdPacienteNavigation = new Paciente()
                        {
                            Cpf = p.IdPacienteNavigation.Cpf,
                            Telefone = p.IdPacienteNavigation.Telefone,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdSituacaoNavigation = new Situacao
                        {
                            Descricao = p.IdSituacaoNavigation.Descricao
                        }
                    })
                    .ToList();
        }
    }
}
