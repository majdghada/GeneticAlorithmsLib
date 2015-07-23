using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithms
{
    namespace Genes
    {
        public class ByteGene : IGene
        {
            private static Random random = new Random();

            private byte value;


            private ByteGene(byte value)
            {
                this.value = value;
            }


            public ByteGene()
            {
                this.value = (byte)ByteGene.random.Next(0, 256);
            }

            public byte GetValue()
            {
                return this.value;
            }



            public void Mutate()
            {
                this.value = (byte)ByteGene.random.Next(0, 256);
            }

            public IGene Clone()
            {
                IGene cpy = new ByteGene(this.value);
                return cpy;
            }


            public override string ToString()
            {
                return this.value.ToString();
            }
        }
    }
}
