using FantasyIsland.Data;
using FantasyIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Services
{
    public class AdminService
    {
        private readonly Guid _adminId;

        public AdminService(Guid adminId)
        {
            _adminId = adminId;
        }

        public bool CreateAdmin(AdminCreate model)
        {
            var entity =
                new Admin()
                {
                    Id = _adminId,
                    Name = model.Name,
                    Email = model.Email,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Admins.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AdminListItem> GetAdmins()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Admins
                    .Where(e => e.Id == _adminId)
                    .Select(
                        e =>
                            new AdminListItem
                            {
                                AdminId = e.AdminId,
                                Name = e.Name,
                            }
                    );
                return query.ToArray();
            }
        }

        public AdminDetail GetAdminById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                     .Admins
                     .Single(e => e.GuestId == id && e.Id == _adminId);
                return
                 new AdminDetail
                 {
                     AdminId = entity.AdminId,
                     Name = entity.Name,
                     Email = entity.Email
                 };
            }
        }

        public bool UpdateAdmin(AdminEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                     .Admins
                     .Single(e => e.GuestId == model.AdminId && e.Id == _adminId);

                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAdmin(int adminId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Admins
                    .Single(e => e.AdminId == adminId && e.Id == _adminId);
                ctx.Admins.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
