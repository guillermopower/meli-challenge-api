using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace meli_challenge_entities
{
    [DataContract(IsReference = true)]
    [Serializable]
    public class StatsServiceResponse: IStatsServiceResponse
    {
        [DataMember]
        public long count_mutant_dna { get; set; }
        [DataMember]
        public long count_human_dna { get; set; }
        [DataMember]
        public decimal ratio { get; set; }
    }
}
