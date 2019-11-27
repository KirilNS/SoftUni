
namespace Prototype
{
    using System;

    public class Sandwich : SandwichPrototype
    {
        private string meat;
        private string bread;
        private string cheese;
        private string vegetable;

        public Sandwich(string meat, string bread, string cheese, string vegetable)
        {
            this.meat = meat;
            this.bread = bread;
            this.cheese = cheese;
            this.vegetable = vegetable;
        }

        public override SandwichPrototype Clone()
        {
            string ingrediantsList = GetIngrediantsList();

            Console.WriteLine("Cloning sandwich with ingrediants: {0}!",ingrediantsList);

            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngrediantsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.vegetable}";
        }
    }
}
