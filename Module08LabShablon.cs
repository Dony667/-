using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Module08Lab
{
    public abstract class Beverage
    {
        public void Recept()
        {
            Kipitit();
            Varit();
            Nalit();
            Pripravi();
        }

        private void Kipitit()
        {
            Console.WriteLine("Кипячение воды...");
        }

        private void Nalit()
        {
            Console.WriteLine("Наливание в чашку...");
        }

        protected abstract void Varit();
        protected abstract void Pripravi();
    }

    public class Tea : Beverage
    {
        protected override void Varit()
        {
            Console.WriteLine("Заваривание чая...");
        }

        protected override void Pripravi()
        {
            Console.WriteLine("Добавление лимона...");
        }
    }

    public class Coffee : Beverage
    {
        protected override void Varit()
        {
            Console.WriteLine("Заваривание кофе...");
        }

        protected override void Pripravi()
        {
            Console.WriteLine("Добавление сахара и молока...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Beverage tea = new Tea();
            Console.WriteLine("Приготовление чая:");
            tea.Recept();

            Console.WriteLine();

            Beverage coffee = new Coffee();
            Console.WriteLine("Приготовление кофе:");
            coffee.Recept();
        }
    }
}
