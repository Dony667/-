using System;

namespace Laba01
{
    public interface ICostShipping
    {
        decimal Cost(decimal weight, decimal distance);
    }

    public class StandardCostShipping : ICostShipping
    {
        public decimal Cost(decimal weight, decimal distance)
        {
            return weight * 0.5m + distance * 0.1m;
        }
    }

    public class ExpressCostShipping : ICostShipping
    {
        public decimal Cost(decimal weight, decimal distance)
        {
            return (weight * 0.9m + distance * 0.2m) + 20;
        }
    }

    public class InternationalCostShipping : ICostShipping
    {
        public decimal Cost(decimal weight, decimal distance)
        {
            return (weight * 2.0m + distance * 0.3m) + 30;
        }
    }

    public class ShippingContext
    {
        private ICostShipping _shippingCost;

        public void SetICostShipping(ICostShipping shipping)
        {
            _shippingCost = shipping;
        }

        public decimal CalculateCost(decimal weight, decimal distance)
        {
            if (_shippingCost == null)
            {
                throw new InvalidOperationException("Не получилось.");
            }
            return _shippingCost.Cost(weight, distance);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ShippingContext shippingContext = new ShippingContext();
            Console.WriteLine("Выберите тип доставки: 1 - Standard, 2 - Express, 3 - International");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    shippingContext.SetICostShipping(new StandardCostShipping());
                    break;
                case "2":
                    shippingContext.SetICostShipping(new ExpressCostShipping());
                    break;
                case "3":
                    shippingContext.SetICostShipping(new InternationalCostShipping());
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            Console.WriteLine("Введите вес посылки (кг):");
            decimal weight = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Введите расстояние доставки (км):");
            decimal distance = Convert.ToDecimal(Console.ReadLine());

            decimal cost = shippingContext.CalculateCost(weight, distance);
            Console.WriteLine($"Стоимость доставки: {cost:C}");
        }
    }
}
