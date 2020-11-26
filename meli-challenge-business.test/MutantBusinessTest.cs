using System.Linq;
using System.Threading.Tasks;
using meli_challenge_dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using meli_challenge_entities;

namespace meli_challenge_business.test
{
    [TestClass]
    public class MutantBusinessTest
    {
        [TestMethod]
        public void TestMethodMutantDimension6()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            Mock<IMutantDAL> mutantDal = new Mock<IMutantDAL>();

            mutantDal.Setup(a => a.Save(dna, true)).Returns(true);

            MutantBusiness mutBss = new MutantBusiness(mutantDal.Object);

            var r =  mutBss.IsMutant(dna);

            Assert.AreEqual(r, true);

            mutantDal.Verify(m => m.Save(dna,true), Times.Once);
        }

        [TestMethod]
        public void TestMethodNoMutantDimension6()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTAATT", "AGACGG", "GCGTCA", "TCACTG" };

            Mock<IMutantDAL> mutantDal = new Mock<IMutantDAL>();

            mutantDal.Setup(a => a.Save(dna, false)).Returns(false);

            MutantBusiness mutBss = new MutantBusiness(mutantDal.Object);

            var r = mutBss.IsMutant(dna);

            Assert.AreEqual(r, false);

            mutantDal.Verify(m => m.Save(dna, false), Times.Once);
        }

        [TestMethod]
        public void TestMethodMutantDimension3()
        {
            string[] dna = { "ATG", "CAG", "TTA"};

            Mock<IMutantDAL> mutantDal = new Mock<IMutantDAL>();

            mutantDal.Setup(a => a.Save(dna, false)).Returns(false);

            MutantBusiness mutBss = new MutantBusiness(mutantDal.Object);

            var r = mutBss.IsMutant(dna);

            Assert.AreEqual(r, false);

            mutantDal.Verify(m => m.Save(dna, false), Times.Never);
        }

        [TestMethod]
        public void TestMethodMutantDimensionNxM()
        {
            string[] dna = { "ATGH", "CAGX", "TTAJ" };

            Mock<IMutantDAL> mutantDal = new Mock<IMutantDAL>();

            mutantDal.Setup(a => a.Save(dna, false)).Returns(false);

            MutantBusiness mutBss = new MutantBusiness(mutantDal.Object);

            var r = mutBss.IsMutant(dna);

            Assert.AreEqual(r, false);

            mutantDal.Verify(m => m.Save(dna, false), Times.Never);
        }

        [TestMethod]
        public void TestMethodNoDNAValid()
        {
            string[] dna = { "QWERTY", "UIOPAS", "DFGHJK", "LÑZXCV", "MENEMM", "PERONN" };

            Mock<IMutantDAL> mutantDal = new Mock<IMutantDAL>();

            mutantDal.Setup(a => a.Save(dna, false)).Returns(false);

            MutantBusiness mutBss = new MutantBusiness(mutantDal.Object);

            var r = mutBss.IsMutant(dna);

            Assert.AreEqual(r, false);

            mutantDal.Verify(m => m.Save(dna, false), Times.Never);
        }

        [TestMethod]
        public void TestMethodGetStatistics()
        {
            StatsServiceResponse data = new StatsServiceResponse() { count_human_dna = 1, count_mutant_dna = 1, ratio = 0.5M };
            Mock<IStatsDAL> statDal = new Mock<IStatsDAL>();

            statDal.Setup(a => a.getStatistics()).Returns(Task.FromResult(data).Result);

            StatsBusiness statsBss = new StatsBusiness(statDal.Object);

            var r =  statsBss.getStatistics();

            Assert.AreEqual(r, data);

            statDal.Verify(m => m.getStatistics(), Times.Once);
        }

    }
}
