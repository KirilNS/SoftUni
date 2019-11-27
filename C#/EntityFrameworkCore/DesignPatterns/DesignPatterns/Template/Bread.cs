using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public abstract class Bread
    {
        public abstract void MixIngrediants();
        public abstract void Bake();
        public virtual void Slice()
        {
            Console.WriteLine("Slicing the "+ GetType().Name+"bread!");
        }

        public void Make()
        {
            MixIngrediants();
            Bake();
            Slice();
        }
    }
}
