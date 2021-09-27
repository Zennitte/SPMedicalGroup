using senai.spmedgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> ListarTodos();
        List<Consulta> ListarPaciente(int id);
        List<Consulta> ListarMedico(int id);
        void Cadastrar(Consulta novaConsulta);
        void Cancelar(int id);
        void Deletar(int id);
        void AlterarDescricao(string novaDescricao, int id);
        Consulta BuscarPorId(int id);
    }
}
