using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Genes
    {
        public class BitGene : IGene
        {
            private static Random random = new Random();
            private static double probability = 0.50;

            private bool bit;

            public BitGene()
            {
                double r = BitGene.random.NextDouble();
                if (r <= BitGene.probability)
                    this.bit = true;
                else
                    this.bit = false;
            }

            private BitGene(bool val)
            {
                this.bit = val;
            }


            public bool GetValue()
            {
                return this.bit;
            }



            public void Mutate()
            {
                this.bit ^= true;
            }

            public IGene Clone()
            {
                return (IGene)(new BitGene(this.bit));
            }

            public override string ToString()
            {
                return (this.bit) ? "1" : "0";
            }
        }
    }
}
