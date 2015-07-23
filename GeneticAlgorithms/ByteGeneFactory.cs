using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Genes
    {
        public class ByteGeneFactory : IGeneFactory
        {

            public IGene GetNewGene()
            {
                IGene instance = new ByteGene();
                return instance;
            }
        }
    }
}
