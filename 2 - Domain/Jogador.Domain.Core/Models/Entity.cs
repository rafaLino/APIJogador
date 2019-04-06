using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Jogador.Domain.Core.Models
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }

        public Entity()
        {

        }
        public void UpdateId(string id)
        {
            Id = id;
        }
    }
}
