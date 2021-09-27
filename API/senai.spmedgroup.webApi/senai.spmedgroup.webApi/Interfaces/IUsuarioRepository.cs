using Microsoft.AspNetCore.Http;
using senai.spmedgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuario novaUsuario);
        void Atualizar(int id, Usuario atualizarUsuario);
        void Deletar(int id);
        List<Usuario> ListarTodos();
        Usuario BuscarPorId(int id);
        Usuario Login(string email, string senha);
        void SalvarPerfil(IFormFile foto, int id);
        string ConsultarPerfil(int id);
    }
}
