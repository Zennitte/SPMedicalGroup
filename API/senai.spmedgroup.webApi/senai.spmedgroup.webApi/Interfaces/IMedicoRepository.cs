using senai.spmedgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();
        void Cadastrar(Medico novaMedico);
        void Atualizar(int id, Medico atualizarMedico);
        void Deletar(int id);
        Medico BuscarPorId(int id);
    }
}
