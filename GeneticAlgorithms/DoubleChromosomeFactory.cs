using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public class DoubleChromosomeFactory : IChromosomeFactory
        {
            private int length;

            public DoubleChromosomeFactory(int length)
            {
                this.length = length;
            }



            public IChromosome GetNewChromosome()
            {
                IChromosome instance = new DoubleChromosome(this.length, new Genes.DoubleGeneFactory());
                return instance;
            }
        }
    }
}
