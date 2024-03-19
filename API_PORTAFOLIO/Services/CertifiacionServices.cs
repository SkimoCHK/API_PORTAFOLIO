using API_PORTAFOLIO.Configuracion;
using API_PORTAFOLIO.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_PORTAFOLIO.Services
{
    public class CertifiacionServices
    {
        private readonly IMongoCollection<Certificacion> _certificationCollection;

        public CertifiacionServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _certificationCollection = database.GetCollection<Certificacion>(databaseSettings.Value.Collection);
        }

        public async Task<List<Certificacion>> getCertificados()
        {
            return await _certificationCollection.Find(c => true).ToListAsync();
        }

        public async Task<Certificacion> GetCertificationById(string id)
        {
            return await _certificationCollection.FindAsync(new BsonDocument { {"_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertCertificado(Certificacion certificacion)
        {
            await _certificationCollection.InsertOneAsync(certificacion);
        }

        public async Task UpdateCertificado(Certificacion certificado)
        {
            var filter = Builders<Certificacion>.Filter.Eq(s => s.id, certificado.id);
            await _certificationCollection.DeleteOneAsync(filter);
        }

        public async Task DeleteCertificado(string id)
        {
            var filter = Builders<Certificacion>.Filter.Eq(s => s.id, id);
            await _certificationCollection.DeleteOneAsync(filter);
        }




    }
}
