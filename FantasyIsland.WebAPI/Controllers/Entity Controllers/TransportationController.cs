using FantasyIsland.Models.Transportation;
using FantasyIsland.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FantasyIsland.WebAPI.Controllers
{
    [Authorize]
    public class TransportationController : ApiController
    {
        private TransService CreateTranService()
        {
            var transService = new TransService();
            return transService;
        }

        public IHttpActionResult Get()
        {
            TransService transService = CreateTranService();
            var transportations = transService.GetTransportations();
            return Ok(transportations);
        }

        public IHttpActionResult Post(TransCreate transportation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTranService();

            if (!service.CreateTrans(transportation))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            TransService transService = CreateTranService();
            var transportation = transService.GetTransById(id);
            return Ok(transportation);
        }

        public IHttpActionResult Put(TransEdit transportation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTranService();

            if (!service.UpdateTransportations(transportation))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTranService();

            if (!service.DeleteTransportations(id))
                return InternalServerError();

            return Ok();
        }
    }
}
