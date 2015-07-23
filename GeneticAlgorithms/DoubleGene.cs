using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Genes
    {
        public class DoubleGene : IGene
        {
            private static Random random = new Random();


            private double value;


            private DoubleGene(double value)
            {
                this.value = value;
            }


            public DoubleGene()
            {
                this.value = DoubleGene.random.NextDouble();
            }

            public double GetValue()
            {
                return this.value;
            }

            public override string ToString()
            {
                return this.value.ToString();
            }




            public void Mutate()
            {
                this.value = DoubleGene.random.NextDouble();
            }

            public IGene Clone()
            {
                IGene cpy = new DoubleGene(this.value);
                return cpy;
            }
        }
    }
}
