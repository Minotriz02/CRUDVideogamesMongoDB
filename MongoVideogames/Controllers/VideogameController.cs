using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoVideogames.Models;
using MongoVideogames.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MongoVideogames.Controllers
{
    public class VideogameController : Controller
    {
        private IVideogameCollection db = new VideogameCollection();
        // GET: VideogameController
        public ActionResult Index()
        {
            var videogames = db.GetAllVideogames();
            return View(videogames);
        }

        // GET: VideogameController/Details/5
        public ActionResult Details(string id)
        {
            var videogame = db.GetVideogameById(id);
            return View(videogame);
        }

        // GET: VideogameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideogameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, IFormFile file)
        {
            try
            {
                var buffer = new byte[file.Length];
                file.OpenReadStream().ReadAsync(buffer);

                var videogame = new Videogame()
                {
                    Name = collection["Name"],
                    Price = int.Parse(collection["Price"]),
                    Publisher = collection["Publisher"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"]),
                    ContentImage = buffer
                };

                db.InsertVideogame(videogame);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideogameController/Edit/5
        public ActionResult Edit(string id)
        {
            var videogame = db.GetVideogameById(id);
            return View(videogame);
        }

        // POST: VideogameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var videogame = new Videogame()
                {
                    Id = new ObjectId(id),
                    Name = collection["Name"],
                    Price = int.Parse(collection["Price"]),
                    Publisher = collection["Publisher"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"])
                };

                db.UpdateVideogame(videogame);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideogameController/Delete/5
        public ActionResult Delete(string id)
        {
            var videogame = db.GetVideogameById(id);
            return View(videogame);
        }

        // POST: VideogameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                db.DeleteVideogame(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
