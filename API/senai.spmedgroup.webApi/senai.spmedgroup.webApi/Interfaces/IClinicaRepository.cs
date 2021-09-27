using senai.spmedgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Interfaces
{
    interface IClinicaRepository
    {
        void Cadastrar(Clinica novaClinica);
        void Atualizar(int id, Clinica clinicaAtualizada);
        void Deletar(int id);
        List<Clinica> ListarTodos();
        Clinica BuscarPorId(int id);
    }
}
