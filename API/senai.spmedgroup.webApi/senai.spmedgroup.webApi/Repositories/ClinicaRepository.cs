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
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedGroupContext ctx = new();

        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(id);

            clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.ToList();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
