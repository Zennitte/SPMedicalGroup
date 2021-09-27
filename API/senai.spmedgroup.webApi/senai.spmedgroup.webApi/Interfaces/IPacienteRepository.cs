using senai.spmedgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Interfaces
{
    interface IPacienteRepository
    {
        void Cadastrar(Paciente novaPaciente);
        void Atualizar(int id, Paciente atualizarPaciente);
        void Deletar(int id);
        List<Paciente> ListarTodos();
        Paciente BuscarPorId(int id);
    }
}
