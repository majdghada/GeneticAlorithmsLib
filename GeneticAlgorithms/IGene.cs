using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Genes
    {
        public interface IGene
        {
            void Mutate();
            IGene Clone();
        }
    }
}
