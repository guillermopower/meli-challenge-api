using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using meli_challenge_dal;
using meli_challenge_entities;
namespace meli_challenge_business
{
    public class StatsBusiness : IStatsBusiness
    {
        protected readonly IStatsDAL statsDal;

        public StatsBusiness(IStatsDAL _statsDal)
        {
            this.statsDal = _statsDal;
        }

        public IStatsServiceResponse getStatistics()
        {
            return statsDal.getStatistics();
        }
    }
}
