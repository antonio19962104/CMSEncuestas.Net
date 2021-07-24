using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Entity;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    [RoutePrefix("api/audience")]
    public class AudienceController : ApiController
    {
        [System.Web.Http.Route("")]
        public IHttpActionResult Post(AudienciaModel audienceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Audience newAudience = AudiencesStore.AddAudience(audienceModel.Name);

            return Ok<Audience>(newAudience);

        }
    }
}
