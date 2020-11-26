using meli_challenge_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace meli_challenge_api.Controllers
{
    public interface IMeliController
    {
        IHttpActionResult mutant([FromBody]MutantServiceRequest model);
        IStatsServiceResponse stats();
    }
}
