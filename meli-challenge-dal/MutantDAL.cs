using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meli_challenge_dal
{
    public class MutantDAL:IMutantDAL
    {
        protected readonly Personas persona;
        
        public MutantDAL()
        {
            this.persona = new Personas();
        }
        
        public bool Save(string[] dna, bool isMutant)
        {
            bool saveSuccessfull = false;

          
                try
                {
                    using (var context = new MELIDBEntities())
                    {
                        StringBuilder sb = new StringBuilder();
                        int dimension = dna[0].Length;
                        dna.ToList().ForEach(x => sb.Append(x));
                        persona.DNA = sb.ToString();
                        persona.ArrayLenght = dimension;
                        persona.IsMutant = isMutant;


                        context.Database.Connection.Open();
                        context.Personas.Add(persona);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {

                }
           
            return saveSuccessfull;
        }
    }
}
