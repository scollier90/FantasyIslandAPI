using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using FantasyIsland.Data;
using FantasyIsland.Models;
using FantasyIsland.Models.BookingModels;

namespace FantasyIsland.Services.Services
{
    public class BookingService
    {
        public BookingService()
        {

        }

        public bool CreateBooking(BookingCreate model)
        {
            var entity =
                new Booking()
                {
                    DestId = model.DestId,
                    TransId = model.TransId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bookings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BookingListItem> GetBookings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Bookings
                    .Where(e => e.BookingId == e.BookingId)
                    .Select(
                        e =>
                        new BookingListItem
                        {
                            DestId = e.DestId,
                            DestName = e.Destination.DestName,
                            TransId = e.TransId,
                            TransType = e.Transportation.TransType
                        }
                    );
                return query.ToArray();
            }
        }

        public BookingDetail GetBookingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Bookings
                    .Single(e => e.BookingId == id);
                return
                    new BookingDetail
                    {
                        DestId = entity.DestId,
                        DestName = entity.Destination.DestName,
                        TransId = entity.TransId,
                        TransType = entity.Transportation.TransType
                    };
            }
        }

        public bool UpdateBooking(BookingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Bookings
                    .Single(e => e.BookingId == model.BookingId);

                entity.DestId = model.DestId;
                entity.TransId = model.TransId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBooking(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Bookings
                    .Single(e => e.BookingId == id);

                ctx.Bookings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
