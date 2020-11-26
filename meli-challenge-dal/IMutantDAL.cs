using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meli_challenge_dal
{
    public interface IMutantDAL
    {
        bool Save(string[] dna, bool isMutant);
    }
}
