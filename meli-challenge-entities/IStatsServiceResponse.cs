using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meli_challenge_entities
{
    public interface IStatsServiceResponse
    {
        long count_mutant_dna { get; set; }
        long count_human_dna { get; set; }
        decimal ratio { get; set; }
    }
}
