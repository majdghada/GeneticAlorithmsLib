using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public class DoubleChromosome : IChromosome
        {
            private static Random random = new Random();
            private static double ratio = 1.0 / 10.0;


            private int length;
            private Genes.DoubleGene[] doubleValues;


            private DoubleChromosome()
            {
            }


            public DoubleChromosome(int length, Genes.DoubleGeneFactory doubleGeneFactory)
            {
                this.length = length;
                this.doubleValues = new Genes.DoubleGene[this.length];
                for (int i = 0; i < this.length; ++i)
                    this.doubleValues[i] = (Genes.DoubleGene)doubleGeneFactory.GetNewGene();
            }

            public Genes.DoubleGene[] GetValues()
            {
                return this.doubleValues;
            }

            public int GetLength()
            {
                return this.length;
            }

            public override string ToString()
            {
                string ret = "";
                for (int i = 0; i < this.length - 1; ++i)
                    ret += this.doubleValues[i].ToString() + " ";
                ret += this.doubleValues[this.length - 1].ToString();
                return ret;
            }


            public void Crossover(IChromosome chromosome)
            {
                int crossoverPoint = DoubleChromosome.random.Next(0, this.length - 1);
                DoubleChromosome doubleChromosome = (DoubleChromosome)chromosome;
                Genes.DoubleGene aux = null;
                for (int i = 0; i <= crossoverPoint; ++i)
                {
                    aux = this.doubleValues[i];
                    this.doubleValues[i] = doubleChromosome.doubleValues[i];
                    doubleChromosome.doubleValues[i] = aux;
                }
            }

            public void Mutate()
            {
                int n = (int)(this.length * DoubleChromosome.ratio);
                for (int i = 0; i < n; ++i)
                {
                    int mutationPoint = DoubleChromosome.random.Next(0, this.length);
                    this.doubleValues[mutationPoint].Mutate();
                }
            }

            public IChromosome Clone()
            {
                DoubleChromosome cpy = new DoubleChromosome();
                cpy.length = this.length;
                cpy.doubleValues = new Genes.DoubleGene[cpy.length];
                for (int i = 0; i < cpy.length; ++i)
                    cpy.doubleValues[i] = (Genes.DoubleGene)this.doubleValues[i].Clone();
                IChromosome copy = (IChromosome)cpy;
                return copy;
            }
        }
    }
}
