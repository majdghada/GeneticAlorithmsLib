using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Populations
    {
        public interface IPopulation
        {
            double GetCrossoverProbability();
            void SetCrossoverProbability(double crossoverProbability);
            void SetCrossoverProbabilityToDefault();

            double GetMutationProbability();
            void SetMutationProbability(double mutationProbability);
            void SetMutationProbabilityToDefault();

            double GetSelectionRate();
            void SetSelectionRate(double selectionRate);
            void SetSelectionRateToDefault();
            
            void Evolve();
            
            Chromosomes.IChromosome[] GetChromosomes();
            Chromosomes.IChromosome GetTheBestChromosome();
            
            double GetTheHighestFitness();
            double GetTheAverageFitness();
            double GetTheSumOfTheFitnesses();
            double[] GetFitnesses();
        }
    }
}
