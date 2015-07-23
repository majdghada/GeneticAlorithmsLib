using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public class ByteChromosomeFactory : IChromosomeFactory
        {
            private int length;

            public ByteChromosomeFactory(int length)
            {
                this.length = length;
            }

            public IChromosome GetNewChromosome()
            {
                IChromosome instance = new ByteChromosome(this.length, new Genes.ByteGeneFactory());
                return instance;
            }
        }
    }
}
