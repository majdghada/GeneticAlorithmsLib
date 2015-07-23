using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace SelectionMethods
    {
        public interface ISelectionMethod
        {
            Chromosomes.IChromosome[] PerformSelection(Populations.IPopulation population, int size);
        }
    }
}
