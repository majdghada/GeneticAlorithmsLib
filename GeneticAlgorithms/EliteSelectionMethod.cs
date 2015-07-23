using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
	namespace SelectionMethods
	{
		public class EliteSelectionMethod:ISelectionMethod
		{
			private static Random random = new Random();
			
			public EliteSelectionMethod()
			{
			}


			//The mergin method.
			private static void Merge (Chromosomes.IChromosome[] individuals, double[] f, int begin, int mid, int end)
			{
				int sz = end - begin + 1;
				double[] tempF = new double[sz];
				Chromosomes.IChromosome[] tempIndividuals = new Chromosomes.IChromosome[sz];
				int i = begin;
				int j = mid + 1;
				int idx = -1;
				while (true) {
					++idx;
					if (f [i] <= f [j]) {
						tempF [idx] = f [j];
						tempIndividuals [idx] = individuals [j];
						++j;
					} else {
						tempF [idx] = f [i];
						tempIndividuals [idx] = individuals [i];
						++i;
					}
					if ((i == mid + 1) || (j == end + 1))
						break;
				}
				for (; i < mid + 1; ++i) {
					++idx;
					tempF [idx] = f [i];
					tempIndividuals [idx] = individuals [i];
				}
				for (; j < end + 1; ++j) {
					++idx;
					tempF [idx] = f [j];
					tempIndividuals [idx] = individuals [j];
				}
				for (int k = 0; k < sz; ++k) {
					f [begin + k] = tempF [k];
					individuals [begin + k] = tempIndividuals [k];
				}
			}
		
		
			//The descending sorting method using the merge sort algorithm.
			private static void Sort (Chromosomes.IChromosome[] individuals, double[] f, int begin, int end)
			{
				if (begin == end)
					return;
				int mid = (begin + end) >> 1;
				Sort (individuals, f, begin, mid);
				Sort (individuals, f, mid + 1, end);
				Merge (individuals, f, begin, mid, end);
			}

			public Chromosomes.IChromosome[] PerformSelection (Populations.IPopulation population, int size)
			{
				//Getting all of the chromosomes that are in population.
				Chromosomes.IChromosome[] individuals = population.GetChromosomes ();
			
			
				//Calculating the number of the those chromosomes.
				int sz = individuals.Length;
			
				//Calculating the fitness of each chromosome.
                double[] f = new double[sz];
                double[] fitnesses = population.GetFitnesses();
                for (int i = 0; i < sz; ++i)
                    f[i] = fitnesses[i];

				//Sorting the population by descending fitness values.
				Sort (individuals, f, 0, sz - 1);

				//Defining the to-be-returned array.
				Chromosomes.IChromosome[] ret = new Chromosomes.IChromosome[size];
				
				//Selecting the parents from the population and putting them in ret.
				for (int i = 0; i < size; ++i)
					ret[i] = individuals[i].Clone();
				
				//Returning the result.
				return ret;

			}

		}
	}

}