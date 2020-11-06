using FantasyIsland.Data;
using FantasyIsland.Models;
using FantasyIsland.Models.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Services
{
    public class GuestService
    {
        private readonly Guid _guestId;
        public GuestService(Guid guestId)
        {
            _guestId = guestId;
        }

        public bool CreateGuest(GuestCreate model)
        {
            var entity =
                new Guest()
                {
                    Id = _guestId,
                    Name = model.Name,
                    Email = model.Email,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Guests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GuestListItem> GetGuests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Guests
                        .Where(e => e.Id == _guestId)
                        .Select(
                            e =>
                                new GuestListItem
                                {
                                    GuestId = e.GuestId,
                                    Name = e.Name
                                }
                        );
                return query.ToArray();
            }
        }

        public GuestDetail GetGuestById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Guests
                        .Single(e => e.GuestId == id && e.Id == _guestId);
                return
                    new GuestDetail
                    {
                        GuestId = entity.GuestId,
                        Name = entity.Name,
                        Email = entity.Email
                    };
            }
        }

        public bool UpdateGuest(GuestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Guests
                        .Single(e => e.GuestId == model.GuestId && e.Id == _guestId);
                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGuest(int guestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Guests
                        .Single(e => e.GuestId == guestId && e.Id == _guestId);
                
                ctx.Guests.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
