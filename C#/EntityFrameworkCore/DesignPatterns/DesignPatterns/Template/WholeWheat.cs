using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
        }

        public override void MixIngrediants()
        {
            Console.WriteLine("Gathering Ingredients for Whole Wheat Bread.");
        }
    }
}
