using MongoVideogames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoVideogames.Repositories
{
    public interface IVideogameCollection
    {
        
        void InsertVideogame(Videogame videogame);
        void UpdateVideogame(Videogame videogame);
        void DeleteVideogame(string id);
        List<Videogame> GetAllVideogames();
        Videogame GetVideogameById(string id);

    }
}
