using FantasyIsland.Data;
using FantasyIsland.Models.Transportation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Services.Services
{
    public class TransService
    {
        public TransService()
        {
  
        }

        public bool CreateTrans(TransCreate model)
        {
            var entity =
                new Transportation()
                {
                    TransType = model.TransType,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transportations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransListItem> GetTransportations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transportations
                        .Where(e => e.TransId == e.TransId)
                        .Select(
                            e =>
                                new TransListItem
                                {
                                    TransId = e.TransId,
                                    TransType = e.TransType,
                                    DestId = e.DestId
                                }
                        );
                return query.ToArray();
            }
        }

        public TransDetail GetTransById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transportations
                        .Single(e => e.TransId == id);
                return
                    new TransDetail
                    {
                        TransId = entity.TransId,
                        TransType = entity.TransType,
                        DestId = entity.DestId
                    };
            }
        }

        public bool UpdateTransportations(TransEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transportations
                        .Single(e => e.TransId == model.TransId);
                entity.TransType = model.TransType;
                entity.DestId = model.DestId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransportations(int TransId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transportations
                        .Single(e => e.TransId == TransId);

                ctx.Transportations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
