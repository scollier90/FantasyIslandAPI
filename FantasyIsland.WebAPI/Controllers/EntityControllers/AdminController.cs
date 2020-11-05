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
using FantasyIsland.WebAPI.Models;
using FantasyIsland.WebAPI.Providers;
using FantasyIsland.WebAPI.Results;
using FantasyIsland.Services;
using FantasyIsland.Data;
using FantasyIsland.Models;

namespace FantasyIsland.WebAPI.Controllers
{
   [Authorize]
   public class AdminController : ApiController
    {
        private AdminService CreateAdminService()
        {
            var adminId = Guid.Parse(User.Identity.GetUserId());
            var adminService = new AdminService(adminId);
            return adminService;
        }

        public IHttpActionResult Get()
        {
            AdminService adminService = CreateAdminService();
            var admins = adminService.GetAdmins();
            return Ok(admins);
        }

        public IHttpActionResult Post(AdminCreate admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdminService();

            if (!service.CreateAdmin(admin))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            AdminService adminService = CreateAdminService();
            var admin = adminService.GetAdminById(id);
            return Ok(admin);
        }

        public IHttpActionResult Put(AdminEdit admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdminService();

            if (!service.UpdateAdmin(admin))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAdminService();

            if (!service.DeleteAdmin(id))
                return InternalServerError();

            return Ok();
        }
    }
}
