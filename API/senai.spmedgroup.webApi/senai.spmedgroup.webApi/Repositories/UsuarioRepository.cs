using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using senai.spmedgroup.webApi.Contexts;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedGroupContext ctx = new();
        public void Atualizar(int id, Usuario atualizarUsuario)
        {
            Usuario userBuscado = BuscarPorId(id);

            userBuscado.IdTipoUsuario = userBuscado.IdTipoUsuario;
            userBuscado.Nome = atualizarUsuario.Nome;
            userBuscado.Email = atualizarUsuario.Email;
            userBuscado.Senha = atualizarUsuario.Senha;

            ctx.Usuarios.Update(userBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novaUsuario)
        {
            ctx.Usuarios.Add(novaUsuario);

            ctx.SaveChanges();
        }

        public string ConsultarPerfil(int id)
        {
            ImagemUsuario imagemBuscada = new();

            imagemBuscada = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == id);

            if (imagemBuscada != null)
            {
                return Convert.ToBase64String(imagemBuscada.Binario);
            }

            return null;
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,
                    IdTipoUsuarioNavigation = new TipoUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        NomeTipo = u.IdTipoUsuarioNavigation.NomeTipo
                    }
                })
                .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }

        public void SalvarPerfil(IFormFile foto, int id)
        {
            ImagemUsuario novaImagem = new();

            using (var ms = new MemoryStream())
            {
                foto.CopyTo(ms);

                novaImagem.Binario = ms.ToArray();

                novaImagem.NomeArquivo = foto.FileName;
                novaImagem.MimeType = foto.FileName.Split('.').Last();
                novaImagem.IdUsuario = id;
            }

            ImagemUsuario imagemExistente = new();
            imagemExistente = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == id);

            if (imagemExistente != null)
            {
                imagemExistente.Binario = novaImagem.Binario;
                imagemExistente.NomeArquivo = novaImagem.NomeArquivo;
                imagemExistente.MimeType = novaImagem.MimeType;
                imagemExistente.IdUsuario = id;

                ctx.ImagemUsuarios.Update(imagemExistente);
            }
            else
            {
                ctx.ImagemUsuarios.Add(novaImagem);
            }

            ctx.SaveChanges();
        }
    }
}
