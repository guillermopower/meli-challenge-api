using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meli_challenge_entities
{
    public class MutantServiceRequest: IMutantServiceRequest
    {
        public string[] dna { get; set; }
    }
}
