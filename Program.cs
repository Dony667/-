using System;

namespace TravelBookingSystem
{
    public interface ICostCalculationStrategy
    {
        decimal CalculateCost(int passengers, bool haveBaggage, TravelClass travelClass, bool hasDiscount);
    }

    public enum TravelClass
    {
        Economy,
        Business
    }

    public class AirTravelCost : ICostCalculationStrategy
    {
        public decimal CalculateCost(int passengers, bool haveBaggage, TravelClass travelClass, bool hasDiscount)
        {
            decimal baseCost = passengers * (travelClass == TravelClass.Business ? 15000 : 10000);
            if (haveBaggage) baseCost += 500 * passengers;
            if (hasDiscount) baseCost *= 0.9m;
            return baseCost;
        }
    }

    public class TrainTravelCost : ICostCalculationStrategy
    {
        public decimal CalculateCost(int passengers, bool haveBaggage, TravelClass travelClass, bool hasDiscount)
        {
            decimal baseCost = passengers * (travelClass == TravelClass.Business ? 5000 : 3000);
            if (haveBaggage) baseCost += 300 * passengers;
            if (hasDiscount) baseCost *= 0.85m; 
            return baseCost;
        }
    }

    public class BusTravelCost : ICostCalculationStrategy
    {
        public decimal CalculateCost(int passengers, bool haveBaggage, TravelClass travelClass, bool hasDiscount)
        {
            decimal baseCost = passengers * (travelClass == TravelClass.Business ? 2000 : 1000);
            if (haveBaggage) baseCost += 100 * passengers;
            if (hasDiscount) baseCost *= 0.8m; 
            return baseCost;
        }
    }

    public class TravelBookingContext
    {
        private ICostCalculationStrategy _costCalculationStrategy;

        public void SetCostCalculationStrategy(ICostCalculationStrategy strategy)
        {
            _costCalculationStrategy = strategy;
        }

        public decimal CalculateCost(int passengers, bool haveBaggage, TravelClass travelClass, bool hasDiscount)
        {
            return _costCalculationStrategy.CalculateCost(passengers, haveBaggage, travelClass, hasDiscount);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TravelBookingContext bookingContext = new TravelBookingContext();

            Console.WriteLine("выберите тип транспорта: 1 - самолет, 2 - поезд, 3 - автобус");
            int transportType = int.Parse(Console.ReadLine());

            Console.WriteLine("введите количество пассажиров:");
            int passengers = int.Parse(Console.ReadLine());

            Console.WriteLine("есть ли багаж? (да/нет):");
            bool haveBaggage = Console.ReadLine().ToLower() == "да";

            Console.WriteLine("выберите класс обслуживания: 1 - эконом, 2 - бизнес");
            TravelClass travelClass = int.Parse(Console.ReadLine()) == 1 ? TravelClass.Economy : TravelClass.Business;

            Console.WriteLine("есть ли скидка? (да/нет):");
            bool hasDiscount = Console.ReadLine().ToLower() == "да";

            switch (transportType)
            {
                case 1:
                    bookingContext.SetCostCalculationStrategy(new AirTravelCost());
                    break;
                case 2:
                    bookingContext.SetCostCalculationStrategy(new TrainTravelCost());
                    break;
                case 3:
                    bookingContext.SetCostCalculationStrategy(new BusTravelCost());
                    break;
                default:
                    Console.WriteLine("неверный выбор транспорта.");
                    return;
            }

            decimal cost = bookingContext.CalculateCost(passengers, haveBaggage, travelClass, hasDiscount);
            Console.WriteLine($"стоимость поездки: {cost} тенге");
        }
    }
}
