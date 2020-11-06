using FantasyIsland.Data;
using FantasyIsland.Models;
using FantasyIsland.Models.Guest;
using FantasyIsland.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FantasyIsland.WebAPI.Controllers
{
    [Authorize]
    public class GuestController : ApiController
    {
        private GuestService CreateGuestService()
        {
            var guestId = Guid.Parse(User.Identity.GetUserId());
            var guestService = new GuestService(guestId);
            return guestService;
        }
        public IHttpActionResult Get()
        {
            GuestService guestService = CreateGuestService();
            var guests = guestService.GetGuests();
            return Ok(guests);
        }
        public IHttpActionResult Post(GuestCreate guest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGuestService();

            if (!service.CreateGuest(guest))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            GuestService guestService = CreateGuestService();
            var guest = guestService.GetGuestById(id);
            return Ok(guest);
        }
        public IHttpActionResult Put(GuestEdit guest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGuestService();

            if (!service.UpdateGuest(guest))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGuestService();

            if (!service.DeleteGuest(id))
                return InternalServerError();

            return Ok();
        }
    }
}
