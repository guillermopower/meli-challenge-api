using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using meli_challenge_api;
using meli_challenge_api.Controllers;
using System.Threading.Tasks;
using Moq;
using meli_challenge_entities;
using meli_challenge_business;
using System.Web.Http;
using System.Net;
using System.Web;

namespace meli_challenge_api.Tests.Controllers
{
    [TestClass]
    public class MeliControllerTest
    {
        [TestMethod]
        public void TestMethod_mutant()
        {
            MutantServiceRequest req = new MutantServiceRequest() { dna = new string[] { "ATGCGA", "CAGTGC", "TTAATT", "AGACGG", "GCGTCA", "TCACTG" } };

            Mock<IMutantBusiness> mutantBss = new Mock<IMutantBusiness>();
            Mock<IStatsBusiness> statsBss = new Mock<IStatsBusiness>();

            mutantBss.Setup(a => a.IsMutant(req.dna, null)).Returns(false);

            MeliController controller = new MeliController(mutantBss.Object, statsBss.Object);

            var r = controller.mutant(req);

            System.Web.Http.Results.StatusCodeResult codeResult = new System.Web.Http.Results.StatusCodeResult(HttpStatusCode.Forbidden, controller);

            Assert.AreEqual(r, codeResult.StatusCode);

            mutantBss.Verify(m => m.IsMutant(req.dna, null), Times.Once);
        }
    }
}
