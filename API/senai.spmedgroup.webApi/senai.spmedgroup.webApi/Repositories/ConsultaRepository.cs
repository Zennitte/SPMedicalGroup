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

        public List<Consulta> ListarMedico(int id)
        {
            Medico medicoBuscado = ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);

            int idMedico = medicoBuscado.IdMedico;

            return ctx.Consultas.Include(c => c.IdPacienteNavigation).Include(c => c.IdMedicoNavigation).Include(c => c.IdSituacaoNavigation).Include(c => c.IdMedicoNavigation.IdClinicaNavigation).Where(c => c.IdConsulta == idMedico).ToList();
        }

        public List<Consulta> ListarPaciente(int id)
        {
            Paciente pacienteBuscado = ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);

            int idPaciente = pacienteBuscado.IdPaciente;

            return ctx.Consultas.Include(c => c.IdPacienteNavigation).Include(c => c.IdMedicoNavigation).Include(c => c.IdSituacaoNavigation).Include(c => c.IdMedicoNavigation.IdClinicaNavigation).Where(c => c.IdConsulta == idPaciente).ToList();
        }

        public List<Consulta> ListarTodos()
        {
            return ctx.Consultas.Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).Include(c => c.IdSituacaoNavigation).Include(c => c.IdMedicoNavigation.IdClinicaNavigation).ToList();
        }
    }
}
