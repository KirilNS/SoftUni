using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngrediants()
        {
            Console.WriteLine("Gathering Ingrediants for Sourdough Bread.");
        }
    }
}
