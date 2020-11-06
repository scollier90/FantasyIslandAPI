
﻿using System;
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
using FantasyIsland.WebAPI.Models;
using FantasyIsland.WebAPI.Providers;
using FantasyIsland.WebAPI.Results;
using FantasyIsland.Services;
using FantasyIsland.Data;
using FantasyIsland.Models;




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
            var guests = guestService.GetGuestById(id);
            return Ok(guests);
        }

        public IHttpActionResult Put(GuestEdit guest)
        {
            if(!ModelState.IsValid)

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
