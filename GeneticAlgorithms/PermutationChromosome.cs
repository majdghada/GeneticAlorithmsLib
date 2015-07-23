using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public class PermutationChromosome : IChromosome
        {
            private static Random random = new Random();
            private static double ratio = 1.0 / 10.0;


            private int length;
            private int[] x;
            
            private PermutationChromosome()
            {
            }
            
            private void Fix()
            {
                bool[] aux = new bool[this.length];
                for (int i = 0; i < this.length; ++i)
                    aux[i] = false;
                for (int i = 0; i < this.length; ++i)
                {
                    if (aux[x[i]])
                        for (int j = 0; j < this.length; ++j)
                            if (!aux[j])
                            {
                                x[i] = j;
                                break;
                            }
                    aux[x[i]] = true;
                }
            }
            
            public PermutationChromosome(int length)
            {
                this.length = length;
                this.x = new int[this.length];
                for (int i = 0; i < this.length; ++i)
                    this.x[i] = PermutationChromosome.random.Next(0, this.length);
                this.Fix();
            }
            
            public int GetTheLength()
            {
                return this.length;
            }
            
            public int[] GetThePermutation()
            {
                int[] permutation = new int[this.length];
                for (int i = 0; i < this.length; ++i)
                    permutation[i] = this.x[i] + 1;
                return permutation;
            }
            
            public override string ToString()
            {
                string ret = "";
                for (int i = 0; i < this.length - 1; ++i)
                {
                    int a = this.x[i] + 1;
                    ret += a.ToString() + " ";
                }
                int b = this.x[this.length - 1] + 1;
                ret += b.ToString();
                return ret;
            }

            public void Crossover(IChromosome chromosome)
            {
                int crossoverPoint = PermutationChromosome.random.Next(0, this.length - 1);
                PermutationChromosome permutationChromosome = (PermutationChromosome)chromosome;
                for (int i = 0; i <= crossoverPoint; ++i)
                {
                    int aux = this.x[i];
                    this.x[i] = permutationChromosome.x[i];
                    permutationChromosome.x[i] = aux;
                }
                this.Fix();
                permutationChromosome.Fix();
            }

            public void Mutate()
            {
                int n = (int)(this.length * PermutationChromosome.ratio);
                for (int i = 0; i < n; ++i)
                {
                    int first = PermutationChromosome.random.Next(0, this.length);
                    int second = PermutationChromosome.random.Next(0, this.length);
                    int aux = this.x[first];
                    this.x[first] = this.x[second];
                    this.x[second] = aux;
                }
            }

            public IChromosome Clone()
            {
                PermutationChromosome cpy = new PermutationChromosome();
                cpy.length = this.length;
                cpy.x = new int[cpy.length];
                for (int i = 0; i < cpy.length; ++i)
                    cpy.x[i] = this.x[i];
                IChromosome copy = cpy;
                return copy;
            }
        }
    }
}
