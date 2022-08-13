using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoVideogames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoVideogames.Repositories
{
    public class VideogameCollection : IVideogameCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Videogame> Collection;
        public GridFSBucket fs;

        public VideogameCollection()
        {
            Collection = _repository.db.GetCollection<Videogame>("Videogames");
            fs = new GridFSBucket(_repository.db);
        }
        public void DeleteVideogame(string id)
        {
            var filter = Builders<Videogame>.Filter.Eq(s => s.Id, new ObjectId(id));
            Collection.DeleteOneAsync(filter);
        }

        public List<Videogame> GetAllVideogames()
        {
            var query = Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }

        public Videogame GetVideogameById(string id)
        {
            var videogame = Collection.Find(new BsonDocument{ { "_id", new ObjectId(id) } }).FirstAsync().Result;
            return videogame;
        }

        public void InsertVideogame(Videogame videogame)
        {
            Collection.InsertOneAsync(videogame);
        }

        public void UpdateVideogame(Videogame videogame)
        {
            var filter = Builders<Videogame>.Filter.Eq(s => s.Id, videogame.Id);
            Collection.ReplaceOneAsync(filter, videogame);
        }
    }
}
