using FantasyIsland.Data;
using FantasyIsland.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Services
{
    public class GenreService
    {
        //private readonly int _GenreId = -1;
        public GenreService()
        { }
        
        public bool CreateGenre(GenreCreate model)
        {
            var entity =
                new Genre()
                {
                    
                    GenreType = model.GenreType,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GenreListItem> GetGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Genres
                    .Where(e => e.GenreId == e.GenreId)
                    .Select(
                        e =>
                        new GenreListItem
                        {
                            GenreId = e.GenreId,
                            GenreType = e.GenreType,
                            DestId = e.DestId,
                        }
                        );
                return query.ToArray();
            }
        }

        public GenreDetail GetGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                    .Genres
                    .Single(e => e.GenreId == id);
                return
                    new GenreDetail
                    {
                        GenreId = entity.GenreId,
                        GenreType = entity.GenreType,
                        DestId = entity.DestId,
                    };
            }
        }
        //Find Genre and Update Information given (name/email only)
        public bool UpdateGenre(GenreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                   .Genres
                   .Single(e => e.GenreId == model.GenreId);

                entity.GenreType = model.GenreType;
                entity.GenreId = model.GenreId;
                entity.DestId = model.DestId;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Genre based on matching Genre id and the guid id

        public bool DeleteGenre(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                   .Genres
                   .Single(e => e.GenreId == genreId);

                ctx.Genres.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
