using MongoDB.Driver;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly IMongoCollection<Localizacao> _localizacoes;

        public LocalizacaoRepository()
        {
            _localizacoes = new MongoClient("mongodb://localhost:27017").GetDatabase("spmed").GetCollection<Localizacao>("mapas");
            //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Zennitte:<Camargo18062005>@spmed.9sl7r.mongodb.net/spmed?retryWrites=true&w=majority");
            //var client = new MongoClient(settings);
            //var database = client.GetDatabase("spmed");
            //_localizacoes = database.GetCollection<Localizacao>("mapas");
        }
        public void Cadastrar(List<Localizacao> novaLocalizacao)
        {
            _localizacoes.InsertMany(novaLocalizacao);
        }

        public List<Localizacao> ListarTodas()
        {
            return _localizacoes.Find(localizacao => true).ToList();
        }
    }
}
