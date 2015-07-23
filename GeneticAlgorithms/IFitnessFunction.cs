using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace FitnessFunctions
    {
        public interface IFitnessFunction
        {
            //The fitness should be a positive value
            double GetFitness(Chromosomes.IChromosome chromosome);
        }
    }
}
