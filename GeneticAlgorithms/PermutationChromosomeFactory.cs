using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public class PermutationChromosomeFactory : IChromosomeFactory
        {
            private int length;

            public PermutationChromosomeFactory(int length)
            {
                this.length = length;
            }




            public IChromosome GetNewChromosome()
            {
                IChromosome instance = new PermutationChromosome(this.length);
                return instance;
            }
        }
    }
}
