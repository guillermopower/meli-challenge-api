using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meli_challenge_business
{
    public interface IMutantBusiness
    {
        bool FindSequence(char[,] dna, int dimension);
        bool IsMutant(string[] dna, string pSequenceMutant = null);

    }
}
