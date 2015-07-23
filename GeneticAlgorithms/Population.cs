using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Populations
    {
        public class Population : IPopulation
        {


            private Chromosomes.IChromosome[] individuals;
            private int size;
            private FitnessFunctions.IFitnessFunction fitnessCalculator;
            private SelectionMethods.ISelectionMethod selector;
            private double[] fitnesses; //This array will always be up-to-date.
            private double selectionRate;
            private double crossoverProbability;
            private double mutationProbability;

            private static Random random = new Random();






            public Population(int size, Chromosomes.IChromosomeFactory chromosomeFactory, FitnessFunctions.IFitnessFunction fitnessFunction, SelectionMethods.ISelectionMethod selectionMethod)
            {
                this.SetCrossoverProbabilityToDefault();
                this.SetMutationProbabilityToDefault();
                this.SetSelectionRateToDefault();

                this.size = size;
                this.individuals = new Chromosomes.IChromosome[size];
                for (int i = 0; i < size; ++i)
                    this.individuals[i] = chromosomeFactory.GetNewChromosome();
                this.fitnessCalculator = fitnessFunction;
                this.selector = selectionMethod;
                this.fitnesses = new double[this.size];
                for (int i = 0; i < this.size; ++i)
                    this.fitnesses[i] = this.fitnessCalculator.GetFitness(this.individuals[i]);
            }





            public double[] GetFitnesses()
            {
                return this.fitnesses;
            }





            public double GetCrossoverProbability()
            {
                return this.crossoverProbability;
            }





            public double GetSelectionRate()
            {
                return this.selectionRate;
            }





            public void SetSelectionRate(double selectionRate)
            {
                this.selectionRate = selectionRate;
            }






            public void SetSelectionRateToDefault()
            {
                this.selectionRate = 1.0;
            }








            public double GetMutationProbability()
            {
                return this.mutationProbability;
            }





            public void SetCrossoverProbability(double crossoverProbability)
            {
                this.crossoverProbability = crossoverProbability;
            }




            public void SetCrossoverProbabilityToDefault()
            {
                this.crossoverProbability = 0.7;
            }




            public void SetMutationProbability(double mutationProbability)
            {
                this.mutationProbability = mutationProbability;
            }




            public void SetMutationProbabilityToDefault()
            {
                this.mutationProbability = 0.01;
            }





            public Chromosomes.IChromosome[] GetChromosomes()
            {
                return this.individuals;
            }





            public void Evolve()
            {
                //Selection.
                Chromosomes.IChromosome[] parents = this.selector.PerformSelection(this, (int)(this.size * this.selectionRate));
                //--------------------------------------


                //Crossover.
                int nP = parents.Length;
                for (int i = 1; i < nP; i += 2)
                    if (Population.random.NextDouble() <= this.crossoverProbability)
                        parents[i].Crossover(parents[i - 1]);
                //--------------------------------------



                //Mutation.
                for (int i = 0; i < nP; ++i)
                    if (Population.random.NextDouble() <= this.mutationProbability)
                        parents[i].Mutate();
                //--------------------------------------



                //Update.
                if (nP == this.size)
                    this.individuals = parents;
                else
                {
                    Chromosomes.IChromosome[] migrants = this.selector.PerformSelection(this, this.size - nP);
                    List<Chromosomes.IChromosome> lst = new List<Chromosomes.IChromosome>();
                    for (int i = 0; i < nP; ++i)
                        lst.Add(parents[i]);
                    for (int i = 0; i < this.size - nP; ++i)
                        lst.Add(migrants[i]);
                    this.individuals = lst.ToArray();
                }

                for (int i = 0; i < this.size; ++i)
                    this.fitnesses[i] = this.fitnessCalculator.GetFitness(this.individuals[i]);
                //--------------------------------------
            }





            public Chromosomes.IChromosome GetTheBestChromosome()
            {
                double maximum = this.fitnesses[0];
                int idx = 0;
                for (int i = 1; i < this.size; ++i)
                    if (this.fitnesses[i] > maximum)
                    {
                        maximum = this.fitnesses[i];
                        idx = i;
                    }
                return this.individuals[idx];
            }





            public double GetTheHighestFitness()
            {
                double maximum = this.fitnesses[0];
                for (int i = 1; i < this.size; ++i)
                    maximum = Math.Max(maximum, this.fitnesses[i]);
                return maximum;
            }







            public double GetTheAverageFitness()
            {
                return this.GetTheSumOfTheFitnesses() / this.size;
            }




            public double GetTheSumOfTheFitnesses()
            {
                double sum = 0;
                for (int i = 0; i < this.size; ++i)
                    sum += this.fitnesses[i];
                return sum;
            }



        }
    }
}
