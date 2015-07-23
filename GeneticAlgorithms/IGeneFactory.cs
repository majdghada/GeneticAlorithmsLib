using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Genes
    {
        public interface IGeneFactory
        {
            IGene GetNewGene();
        }
    }
}
