using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore.Models;

namespace MVCMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            //Connect to db to retrieve genre titles
            var genres = storeDB.Genres.ToList();
            return View(genres);

            //This was hard coded when we were not using a database
            //var genres = new List<Genre>
            //{
            //    new Genre { Name = "Disco"},
            //    new Genre { Name = "Jazz"},
            //    new Genre { Name = "Rock"}
            //};
            //return View(genres);
        }

        //GET: /Store/Browse    
        /*
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }
        */

        //GET: /Store/Browse?genre=Metal
        /*
         *  Changing the browse action method to retrieve a querystring value from the URL by adding a genre 
         *  parameter to the action method
         */
        //public string Browse(string genre)
        //{
        //    string msg = HttpUtility.HtmlEncode("Store.Browse, genre = " + genre);
        //    return msg;
        //}

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);

            /*
             * Sample data
            var genreModel = new Genre { Name = genre };
            return View(genreModel);
             */
        }

        ////get: /store/details
        //public string details(int id)
        //{
        //    string msg = httputility.htmlencode("hello from store.details, id = " + id);
        //    return msg;
        //}

        //GET: /Store/Details
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);

            return View(album);

            /*
            var album = new Album { Title = "Album " + id };
            return View(album);
             * */
        }

        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }

    }
}
