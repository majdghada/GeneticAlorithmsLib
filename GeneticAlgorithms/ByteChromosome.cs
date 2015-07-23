using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Chromosomes
    {
        public class ByteChromosome : IChromosome
        {
            private static Random random = new Random();
            private static double ratio = 1.0 / 10.0;


            private int length;
            private Genes.ByteGene[] bytes;


            private ByteChromosome()
            {
            }


            public ByteChromosome(int length, Genes.ByteGeneFactory byteFactory)
            {
                this.length = length;
                this.bytes = new Genes.ByteGene[this.length];
                for (int i = 0; i < this.length; ++i)
                    this.bytes[i] = (Genes.ByteGene)byteFactory.GetNewGene();
            }

            public int GetLength()
            {
                return this.length;
            }

            public Genes.ByteGene[] GetBytes()
            {
                return this.bytes;
            }


            public override string ToString()
            {
                string ret = "";
                for (int i = 0; i < this.length - 1; ++i)
                    ret += this.bytes[i].ToString() + " ";
                ret += this.bytes[this.length - 1].ToString();
                return ret;
            }

            public void Crossover(IChromosome chromosome)
            {
                int crossoverPoint = ByteChromosome.random.Next(0, this.length - 1);
                Genes.ByteGene aux = null;
                ByteChromosome byteChromosome = (ByteChromosome)chromosome;
                for (int i = 0; i <= crossoverPoint; ++i)
                {
                    aux = this.bytes[i];
                    this.bytes[i] = byteChromosome.bytes[i];
                    byteChromosome.bytes[i] = aux;
                }
            }

            public void Mutate()
            {
                int n = (int)(this.length * ByteChromosome.ratio);
                for (int i = 0; i < n; ++i)
                {
                    int mutationPoint = ByteChromosome.random.Next(0, this.length);
                    this.bytes[mutationPoint].Mutate();
                }
            }

            public IChromosome Clone()
            {
                ByteChromosome cpy = new ByteChromosome();
                cpy.length = this.length;
                cpy.bytes = new Genes.ByteGene[cpy.length];
                for (int i = 0; i < cpy.length; ++i)
                    cpy.bytes[i] = (Genes.ByteGene)this.bytes[i].Clone();
                IChromosome copy = cpy;
                return copy;
            }
        }
    }
}
