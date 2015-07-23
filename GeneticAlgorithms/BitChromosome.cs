using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public class BitChromosome : IChromosome
        {
            private static Random random = new Random();
            private static double ratio = 1.0 / 10.0;


            private int length;
            private Genes.BitGene[] bits;

            private BitChromosome()
            {
            }


            public BitChromosome(int length, Genes.BitGeneFactory bitGeneFactory)
            {
                this.length = length;
                this.bits = new Genes.BitGene[this.length];
                for (int i = 0; i < this.length; ++i)
                    this.bits[i] = (Genes.BitGene)bitGeneFactory.GetNewGene();
            }



            public int GetLength()
            {
                return this.length;
            }

            public Genes.BitGene[] GetBits()
            {
                return this.bits;
            }


            public override string ToString()
            {
                string ret = "";
                for (int i = 0; i < this.length; ++i)
                    ret += this.bits[i].ToString();
                return ret;
            }

            public void Crossover(IChromosome chromosome)
            {
                double crossoverPoint = BitChromosome.random.Next(0, this.length - 1);
                Genes.BitGene aux = null;
                BitChromosome bitChromosome = (BitChromosome)chromosome;
                for (int i = 0; i <= crossoverPoint; ++i)
                {
                    aux = this.bits[i];
                    this.bits[i] = bitChromosome.bits[i];
                    bitChromosome.bits[i] = aux;
                }
            }

            public void Mutate()
            {
                int n = (int)(this.length * BitChromosome.ratio);
                for (int i = 0; i < n; ++i)
                {
                    int mutationPoint = BitChromosome.random.Next(0, this.length);
                    this.bits[mutationPoint].Mutate();
                }
            }


            public IChromosome Clone()
            {
                BitChromosome cpy = new BitChromosome();
                cpy.length = this.length;
                cpy.bits = new Genes.BitGene[cpy.length];
                for (int i = 0; i < cpy.length; ++i)
                    cpy.bits[i] = (Genes.BitGene)this.bits[i].Clone();
                return (IChromosome)cpy;
            }
        }
    }
}
