using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoVideogames.Models
{
    public class Videogame
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public byte[] ContentImage { get; set; }

    }
}
