using Jogador.Domain.Core.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Jogador.Domain.Models
{
   public class Player : Entity
    {
        [BsonElement("Name")]
        public string Name { get; private set; }

        [BsonElement("Age")]
        public int Age { get; private set; }

        [BsonElement("Position")]
        public string Position { get; private set; }

        [BsonElement("ImgPath")]
        public string ImgPath { get; set; }

        public Player()
        {

        }
        public Player(string name, int age, string position)
        {
            Name = name;
            Age = age;
            Position = position;
        }
        
    }
}
