using FantasyIsland.Models;
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
