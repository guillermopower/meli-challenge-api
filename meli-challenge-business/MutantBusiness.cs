using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using meli_challenge_entities;
using meli_challenge_dal;

namespace meli_challenge_business
{
    public class MutantBusiness:IMutantBusiness
    {
        string sequenceMutant = "ATCG";
        char[,] matrix;
        int dimension = 0;
        const int CountCharGroup = 4;

        protected readonly IMutantDAL mutantDAL;
        public MutantBusiness(IMutantDAL _mutantDAL)
        {
            this.mutantDAL = _mutantDAL;
        }
        
        public bool IsMutant(string[] dna, string pSequenceMutant = null)
        {
            bool resp = false;
            try
            {
                if (!string.IsNullOrEmpty(pSequenceMutant)) sequenceMutant = pSequenceMutant;
                resp = (ArrayHasValidFormat(dna, ref dimension));
                if (resp)
                {
                    this.matrix = new char[dimension, dimension];
                    resp = this.HasNitrogenedBase(dna.ToList(), dimension);
                    this.matrix = setCharacterPositions(dna, dimension);

                    if (resp)
                    {
                        resp = FindSequence(this.matrix, dimension);
                        resp = mutantDAL.Save(dna, resp);
                    }
                }
            }
            catch 
            {
                resp = false;
            }
            finally
            {

            }
            return resp;
          
        }
       
        private char[,] setCharacterPositions(string[] dna, int dimension)
        {
            char[,] matrix = new char[dimension,dimension];
            int i = 0;
            dna.ToList().ForEach(x => {
               
                int j = 0;
                x.ToList().ForEach(y =>
                {
                    matrix.SetValue(y, i, j);
                    j++;
                }
                );
                i++;
            });

            return matrix;
        }

        private bool ArrayHasValidFormat(string[] dna, ref int n)
        {
            bool r = false;
            int cols = dna.FirstOrDefault().Length;
            int row = dna.Length;

            if(cols != row)
            {
                r = false;
            }
            else
            {
                n = cols;
                r = true;
            }

            return (n >= CountCharGroup);
        }

        private bool HasNitrogenedBase(List<string> dna, int dimension)
        {
            int countByRow = 0;
            foreach (string x in dna.ToList())
            {
                int countByCol = 0;
                foreach (char y in x.ToList())
                {
                    if (sequenceMutant.Contains(y))
                    {
                        countByCol++;
                    }
                }
                if (countByCol == dimension) countByRow++; else break;
            }
            return countByRow == dimension ;
        }

        public bool FindSequence(char[,] dna, int dimension)
        {
            int value = 0;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    value = findHorizontalSequence(dna, i, j, dimension) ? value + 1 : value;
                    value = findVerticalSequence(dna, i, j, dimension) ? value + 1 : value;
                    value = findDiagonalAscendentSequence(dna, i, j, dimension) ? value + 1 : value;
                    value = findDiagonalDescendentSequence(dna, i, j, dimension) ? value + 1 : value;
                }
            }
            return value > 0;
        }

        private bool findHorizontalSequence(char[,] dna, int i, int j, int dimension)
        {
            //Sequence HORIZONTAL
            if (j + 3 < dimension - 1)
            {
                if (dna[i, j] == dna[i, j + 1] &&
                    dna[i, j + 2] == dna[i, j + 3] &&
                    dna[i, j] == dna[i, j + 3])
                {
                    return true;

                }
            }
            return false;
        }

        private bool findVerticalSequence(char[,] dna, int i, int j, int dimension)
        {
            //Sequence VERTICAL
            if (i + 3 < dimension - 1)
            {
                if (dna[i, j] == dna[i + 1, j] &&
                    dna[i + 2, j] == dna[i + 3, j] &&
                    dna[i, j] == dna[i + 3, j]
                    )
                {
                    return true;

                }
            }
            return false;
        }

        private bool findDiagonalAscendentSequence(char[,] dna, int i, int j, int dimension)
        {
            //Sequence OBLICUA ASCENDENTE
            if ((i > 2) && ((j < dimension - 3)))
            {
                if (dna[i, j] == dna[i - 1, j + 1] &&
                    dna[i - 2, j + 2] == dna[i - 3, j + 3] &&
                    dna[i, j] == dna[i - 3, j + 3])
                {
                    return true;

                }
            }
            return false;
        }

        private bool findDiagonalDescendentSequence(char[,] dna, int i, int j, int dimension)
        {
            //Sequence OBLICUA DESCENDENTE
            if ((i + 3 < dimension - 1) && (j + 3 < dimension - 1))
            {
                if (dna[i, j] == dna[i + 1, j + 1] &&
                   dna[i + 2, j + 2] == dna[i + 3, j + 3] &&
                   dna[i, j] == dna[i + 3, j + 3])
                {
                    return true;
                }
            }
            return false;
        }

    }
}
