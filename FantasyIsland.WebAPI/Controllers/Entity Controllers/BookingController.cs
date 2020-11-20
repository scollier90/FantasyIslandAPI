using FantasyIsland.Data;
using FantasyIsland.Models;
using FantasyIsland.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;

namespace FantasyIsland.WebAPI.Controllers
{
    [Authorize]
    public class BookingController : ApiController
    {
        private BookingService CreateBookingService()
        {
            var bookingService = new BookingService();
            return bookingService;
        }

        //private ApplicationUser GetCurrentUser(ApplicationDbContext context)
        //{
        //    var identity = User.Identity as ClaimsIdentity;
        //    Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        //    return context.Users.FirstOrDefault(u => u.Id == identityClaim.Value);
        //}

        //public string GetUserId(this IPrincipal principal)
        //{
        //    var claimsIdentity = (ClaimsIdentity)principal.Identity;
        //    var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        //    return claim.Value;
        //}

        public IHttpActionResult Get()
        {
            BookingService bookingService = CreateBookingService();
            var bookings = bookingService.GetBookings();
            return Ok(bookings);
        }

        public IHttpActionResult Post(BookingCreate booking)
        {
            booking.UserId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookingService();

            if (!service.CreateBooking(booking))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(BookingEdit booking)
        {
            booking.UserId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookingService();

            if (!service.UpdateBooking(booking))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateBookingService();

            if (!service.DeleteBooking(id))
                return InternalServerError();

            return Ok();
        }
    }
}
