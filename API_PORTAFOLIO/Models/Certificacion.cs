using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_PORTAFOLIO.Models
{
    public class Certificacion
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public string id { get; set; } = string.Empty;

        [BsonElement("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [BsonElement("Entidad")]
        public string Entidad { get; set; } = string.Empty;


    }
}
