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
    public class PacienteRepository : IPacienteRepository
    {
        SpMedGroupContext ctx = new();
        public void Atualizar(int id, Paciente atualizarPaciente)
        {
            Paciente pacienteBuscado = BuscarPorId(id);

            pacienteBuscado.IdUsuario = pacienteBuscado.IdUsuario;
            pacienteBuscado.DataNasc = atualizarPaciente.DataNasc;
            pacienteBuscado.Telefone = atualizarPaciente.Telefone;
            pacienteBuscado.Rg = atualizarPaciente.Rg;
            pacienteBuscado.Cpf = atualizarPaciente.Cpf;
            pacienteBuscado.Endereco = atualizarPaciente.Endereco;

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Cadastrar(Paciente novaPaciente)
        {
            ctx.Pacientes.Add(novaPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pacientes.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
