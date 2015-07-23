using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public class BitChromosomeFactory : IChromosomeFactory
        {
            private int length;


            public BitChromosomeFactory(int length)
            {
                this.length = length;
            }



            public IChromosome GetNewChromosome()
            {
                IChromosome ret = new BitChromosome(this.length, new Genes.BitGeneFactory());
                return ret;
            }
        }
    }
}
