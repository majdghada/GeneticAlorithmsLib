using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public interface IChromosomeFactory
        {
            IChromosome GetNewChromosome();
        }
    }
}
