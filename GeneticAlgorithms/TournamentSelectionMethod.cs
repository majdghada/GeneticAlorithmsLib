using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
	namespace SelectionMethods
	{
		public class TournamentSelectionMethod:ISelectionMethod
		{
			private static Random random = new Random();

			private int TournamentSize;

			public TournamentSelectionMethod (int tournamentSize)
			{
				TournamentSize=tournamentSize;
			}


			public Chromosomes.IChromosome[] PerformSelection (Populations.IPopulation population, int size)
			{
				//Getting all of the chromosomes that are in population.
				Chromosomes.IChromosome[] individuals = population.GetChromosomes();
				
				
				//Calculating the number of the those chromosomes.
				int sz = individuals.Length;
				
				//Calculating the fitness of each chromosome.
                double[] f = new double[sz];
                double[] fitnesses = population.GetFitnesses();
                for (int i = 0; i < sz; ++i)
                    f[i] = fitnesses[i];

				//Defining the to-be-returned array.
				Chromosomes.IChromosome[] ret = new Chromosomes.IChromosome[size];
				
				//Selecting the parents from the population and putting them in ret.
				for (int i = 0; i < size; ++i)
				{
					int parentidx=-1;
					for (int j=0;j<TournamentSize;++j){
						int idx=random.Next(size);
						if (parentidx==-1||f[parentidx]<f[idx]){
							parentidx=idx;
						}
					}
					ret[i]=individuals[parentidx].Clone();
				}
				//Returning the result.
				return ret;



			}

		}
	}
}

