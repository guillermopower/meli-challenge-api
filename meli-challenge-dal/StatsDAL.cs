using meli_challenge_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace meli_challenge_dal
{
    public class StatsDAL : IStatsDAL
    {
        private readonly IStatsServiceResponse statsServiceResponse;

        public StatsDAL(IStatsServiceResponse _statsServiceResponse)
        {
            this.statsServiceResponse = _statsServiceResponse;
        }

        public IStatsServiceResponse getStatistics()
        {
            try
            {
                using (var context = new MELIDBEntities())
                {
                    statsServiceResponse.count_mutant_dna = context.Personas.Select(x => x.IsMutant == true).Count();
                    statsServiceResponse.count_human_dna = context.Personas.Select(x => x.IsMutant == false).Count();
                    statsServiceResponse.ratio = statsServiceResponse.count_human_dna>0 ? Math.Round(Convert.ToDecimal(statsServiceResponse.count_mutant_dna) / (Convert.ToDecimal(statsServiceResponse.count_mutant_dna) + Convert.ToDecimal(statsServiceResponse.count_human_dna)),4):0;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return this.statsServiceResponse;
        }

    }
}
