using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Genes
    {
        public class BitGeneFactory : IGeneFactory
        {
            public IGene GetNewGene()
            {
                IGene ret = new BitGene();
                return ret;
            }
        }
    }
}
