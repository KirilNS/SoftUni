using System;

namespace Composite
{
    public class StartUp
    {
        public static void Main()
        {
            var phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            var rootBox = new CompositeGift("RootBox", 0);
            var truckToy = new SingleGift("TruckToy", 289);
            var plaiToy = new SingleGift("PlainToy", 587);
            rootBox.Add(truckToy);
            rootBox.Add(plaiToy);
            var childBox = new CompositeGift("ChildBox", 0);
            var soldierToy = new SingleGift("SoldierToy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is:{rootBox.CalculateTotalPrice()}");
        }
    }
}
