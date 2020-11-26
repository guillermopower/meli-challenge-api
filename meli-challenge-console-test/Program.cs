using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using meli_challenge_business;
using meli_challenge_dal;
using meli_challenge_entities;

namespace meli_challenge_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            MutantBusiness servMut = new MutantBusiness(new MutantDAL());
            StatsBusiness  servBss = new StatsBusiness(new StatsDAL( new StatsServiceResponse()));
            //List<string> dna = new List<string>() { "ATGCGA", "CAGTGC", "TTAATT", "AGACGG", "GCGTCA", "TCACTG" };
            //List<string> dna = new List<string>() { "GCGA", "GTAC","GATT", "AAGG" };
            //List<string> dna = new List<string>() { "QWERTY", "UIOPAS", "DFGHJK", "LÑZXCV", "MENEMM", "PERONN" };
            List<string> dna = new List<string>() { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            //List<string> dna = new List<string>() { "ATG", "CAG", "TTA" };
            int dimension = 0;
            /*
            Console.WriteLine("ArrayHasValidFormat Method:");
            Console.WriteLine(serv.ArrayHasValidFormat(dna.ToArray(), ref dimension));
            Console.WriteLine("la dimension del array es " + dimension.ToString());

            Console.WriteLine("HasNitrogenedBase Method:");
            Console.WriteLine(serv.HasNitrogenedBase(dna, dimension));
                       

            Console.WriteLine("setCharacterPositions Method:");
            char [,] matrix = serv.setCharacterPositions(dna.ToArray(), dimension);

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(" {0}", matrix[i,j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("horizontalSequence Method:");
            Console.WriteLine(serv.FindSequence(matrix, dimension));
            */

            Console.WriteLine("IsMutant Method:");
            Console.WriteLine(servMut.IsMutant(dna.ToArray()));
            var resp = servBss.getStatistics();
            Console.WriteLine("count_human_dna:" + resp.count_human_dna.ToString() + Environment.NewLine
                + "count_mutant_dna: " + resp.count_mutant_dna.ToString() + Environment.NewLine
                + "ratio: " + resp.ratio.ToString());
            
            Console.ReadKey();
            
        }
    }
}
