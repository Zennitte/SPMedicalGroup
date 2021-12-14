using senai.spmedgroup.webApi.Domains;
using System.Collections.Generic;

namespace senai.spmedgroup.webApi.Interfaces
{
    interface ILocalizacaoRepository
    {
        List<Localizacao> ListarTodas();
        void Cadastrar(List<Localizacao> novaLocalizacao);
    }
}
