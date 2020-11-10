<<<<<<< HEAD
﻿using FantasyIsland.Models.DestinationModels;
using FantasyIsland.Services;
using System;
=======
﻿using System;
>>>>>>> 68b4f798ad41af0d8f2519c8355cd7f23a2bc990
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

<<<<<<< HEAD
namespace FantasyIsland.WebAPI.Controllers.Entity_Controllers
=======
namespace FantasyIsland.WebAPI.Controllers
>>>>>>> 68b4f798ad41af0d8f2519c8355cd7f23a2bc990
{
    [Authorize]
    public class DestinationController : ApiController
    {

<<<<<<< HEAD
        private DestService CreateDestService()
        {
            var destService = new DestService();
            return destService;
        }

        public IHttpActionResult Get()
        {
            DestService destService = CreateDestService();
            var destinations = destService.GetDestinations();
            return Ok(destinations);
        }

        public IHttpActionResult Post(DestCreate destination)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDestService();

            if (!service.CreateDestination(destination))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            DestService destService = CreateDestService();
            var destination = destService.GetDestinationById(id);
            return Ok(destination);
        }

        public IHttpActionResult Put(DestEdit destination)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDestService();

            if (!service.UpdateDestination(destination))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateDestService();

            if (!service.DeleteDest(id))
                return InternalServerError();

            return Ok();
        }

=======
>>>>>>> 68b4f798ad41af0d8f2519c8355cd7f23a2bc990
    }
}
