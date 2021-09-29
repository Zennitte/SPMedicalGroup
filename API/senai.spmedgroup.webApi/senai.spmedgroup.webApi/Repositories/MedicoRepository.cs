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
    public class MedicoRepository : IMedicoRepository
    {
        SpMedGroupContext ctx = new();
        public void Atualizar(int id, Medico atualizarMedico)
        {
            Medico medicoBuscado = BuscarPorId(id);

            medicoBuscado.IdUsuario = medicoBuscado.IdUsuario;
            medicoBuscado.IdEspecializacao = atualizarMedico.IdEspecializacao;
            medicoBuscado.IdClinica = atualizarMedico.IdClinica;
            medicoBuscado.Crm = atualizarMedico.Crm;

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdUsuario == id);
        }

        public void Cadastrar(Medico novaMedico)
        {
            ctx.Medicos.Add(novaMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Medicos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.Include(m => m.IdClinicaNavigation).Include(m => m.IdEspecializacaoNavigation).Include(m => m.IdUsuarioNavigation).ToList();
        }
    }
}
