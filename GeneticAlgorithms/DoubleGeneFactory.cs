using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Genes
    {
        public class DoubleGeneFactory : IGeneFactory
        {
            public IGene GetNewGene()
            {
                IGene instance = new DoubleGene();
                return instance;
            }
        }
    }
}
