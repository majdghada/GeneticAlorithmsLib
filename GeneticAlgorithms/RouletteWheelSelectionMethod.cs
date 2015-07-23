using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace SelectionMethods
    {
        public class RouletteWheelSelectionMethod : ISelectionMethod
        {


            private static Random random = new Random();



            public RouletteWheelSelectionMethod()
            {
            }


            //The mergin method.
            private static void Merge(Chromosomes.IChromosome[] individuals, double[] f, int begin, int mid, int end)
            {
                int sz = end - begin + 1;
                double[] tempF = new double[sz];
                Chromosomes.IChromosome[] tempIndividuals = new Chromosomes.IChromosome[sz];
                int i = begin;
                int j = mid + 1;
                int idx = -1;
                while (true)
                {
                    ++idx;
                    if (f[i] <= f[j])
                    {
                        tempF[idx] = f[j];
                        tempIndividuals[idx] = individuals[j];
                        ++j;
                    }
                    else
                    {
                        tempF[idx] = f[i];
                        tempIndividuals[idx] = individuals[i];
                        ++i;
                    }
                    if ((i == mid + 1) || (j == end + 1))
                        break;
                }
                for (; i < mid + 1; ++i)
                {
                    ++idx;
                    tempF[idx] = f[i];
                    tempIndividuals[idx] = individuals[i];
                }
                for (; j < end + 1; ++j)
                {
                    ++idx;
                    tempF[idx] = f[j];
                    tempIndividuals[idx] = individuals[j];
                }
                for (int k = 0; k < sz; ++k)
                {
                    f[begin + k] = tempF[k];
                    individuals[begin + k] = tempIndividuals[k];
                }
            }





            //The descending sorting method using the merge sort algorithm.
            private static void Sort(Chromosomes.IChromosome[] individuals, double[] f, int begin, int end)
            {
                if (begin == end)
                    return;
                int mid = (begin + end) >> 1;
                RouletteWheelSelectionMethod.Sort(individuals, f, begin, mid);
                RouletteWheelSelectionMethod.Sort(individuals, f, mid + 1, end);
                RouletteWheelSelectionMethod.Merge(individuals, f, begin, mid, end);
            }








            //The finding method using the binary search approach.
            private static int Find(double[] f, double r)
            {
                int begin = 0;
                int end = f.Length - 1;
                int idx = -1;
                while (begin <= end)
                {
                    int mid = (begin + end) >> 1;
                    if (f[mid] > r)
                    {
                        idx = mid;
                        end = mid - 1;
                    }
                    else
                        begin = mid + 1;
                }
                return idx;
            }






            public Chromosomes.IChromosome[] PerformSelection(Populations.IPopulation population, int size)
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

                //Calculating the sum of the fitnesses.
                double sum = 0.0;
                for (int i = 0; i < sz; ++i)
                    sum += f[i];


                //The normalization step.
                for (int i = 0; i < sz; ++i)
                    f[i] /= sum;


                //Sorting the population by descending fitness values.
                RouletteWheelSelectionMethod.Sort(individuals, f, 0, sz - 1);

                //The accumulation step.
                for (int i = 1; i < sz; ++i)
                    f[i] += f[i - 1];

                f[sz - 1] = 1.0; //To ensure that the sum of all the fitnesses is equal to 1.0.


                //Defining the to-be-returned array.
                Chromosomes.IChromosome[] ret = new Chromosomes.IChromosome[size];



                //Selecting the parents from the population and putting them in ret.
                for (int i = 0; i < size; ++i)
                {
                    int idx = RouletteWheelSelectionMethod.Find(f, RouletteWheelSelectionMethod.random.NextDouble());
                    ret[i] = individuals[idx].Clone();
                }

                //Returning the result.
                return ret;
            }



        }
    }
}
