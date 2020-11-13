using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using FantasyIsland.WebAPI.Data;
using FantasyIsland.WebAPI.Providers;
using FantasyIsland.WebAPI.Results;
using FantasyIsland.Services;
using FantasyIsland.Data;
using FantasyIsland.Models;
using FantasyIsland.Models.GenreModels;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace FantasyIsland.WebAPI.Controllers
{
    [Authorize]
    public class GenreController : ApiController
    {
        private GenreService CreateGenreService()
        {
            var GenreService = new GenreService();
            return GenreService;
        }

        public IHttpActionResult Get()
        {
            GenreService GenreService = CreateGenreService();
            var Genres = GenreService.GetGenres();
            return Ok(Genres);
        }

        public IHttpActionResult Post(GenreCreate Genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.CreateGenre(Genre))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            GenreService GenreService = CreateGenreService();
            var Genres = GenreService.GetGenreById(id);
            return Ok(Genres);
        }

        public IHttpActionResult Put(GenreEdit Genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.UpdateGenre(Genre))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateGenreService();

            if (!service.DeleteGenre(id))
                return InternalServerError();

            return Ok();
        }
    }
}
