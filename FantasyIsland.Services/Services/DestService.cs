using FantasyIsland.Data;
using FantasyIsland.Models;
using FantasyIsland.Models.BookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Services
{
    public class DestService
    {
        public DestService()
        {
        
        }

        //Create a new destination
        public bool CreateDestination(DestCreate model)
        {
            var entity =
                new Destination()
                {
                    DestName = model.DestName,
                    GenreId = model.GenreId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Destinations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Show list of destinations
        public IEnumerable<DestListItem> GetDestinations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Destinations
                    .Where(e => e.DestId == e.DestId)
                    .Select(
                        e =>
                        new DestListItem
                        {
                            DestId = e.DestId,
                            DestName = e.DestName,
                            GenreId = e.GenreId,
                        }
                    );
                return query.ToArray();
            }
        }

        //find destination by id
        public DestDetail GetDestinationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Destinations
                    .Single(e => e.DestId == id);
                return
                 new DestDetail
                 {
                     DestId = entity.DestId,
                     DestName = entity.DestName,
                     GenreId = entity.GenreId,
                 };
            }
        }
        //Find destination and update Info given
        public bool UpdateDestination(DestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Destinations
                    .Single(e => e.DestId == model.DestId);

                entity.DestId = model.DestId;
                entity.DestName = model.DestName;
                entity.GenreId = model.GenreId;
                
                return ctx.SaveChanges() == 1;
            }
        }

        //Delete guest based on matching guest id and the Guid id
        public bool DeleteDest(int destId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Destinations
                    .Single(e => e.DestId == destId);

                ctx.Destinations.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

