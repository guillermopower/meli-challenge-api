using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using meli_challenge_business;
using meli_challenge_entities;


namespace meli_challenge_api.Controllers
{
    [RoutePrefix("api/meli")]
    public class MeliController : ApiController, IMeliController
    {
        private readonly IMutantBusiness mutantBss;
        private readonly IStatsBusiness statsBss;

        public MeliController(IMutantBusiness _mutantBss, IStatsBusiness _statsBss)
        {
            this.mutantBss = _mutantBss;
            this.statsBss = _statsBss;
        }

        [Route("mutant")]
        [HttpPost]
        public IHttpActionResult mutant([FromBody]MutantServiceRequest model)
        {
            bool isMutant =  mutantBss.IsMutant(model.dna);
            if (!isMutant)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }
            return StatusCode(HttpStatusCode.OK);
        }

        [Route("stats")]
        [HttpGet]
        public IStatsServiceResponse stats()
        {
            return statsBss.GetStatistics();
        }
    }
}
 