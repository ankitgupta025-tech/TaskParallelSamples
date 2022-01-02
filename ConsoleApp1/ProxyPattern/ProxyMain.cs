using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using static System.Console;

namespace ConsoleApp1.ProxyPattern
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            WriteLine("driving car");
        }
    }

    public class Driver
    {
        public Driver(int age)
        {
            Age = age;
        }

        public int Age { get; set; }
    }

    public class CarProxy : ICar
    {
        private Driver _driver;
        private Car car = new Car();

        public CarProxy(Driver driver)
        {
            _driver = driver;
        }

        public void Drive()
        {
            if (_driver.Age >= 18)
            {
                car.Drive();
            }
            else
            {
                WriteLine("too young");
            }
        }
    }

    public class ProxyMain: DynamicObject
    {
        public static void Execute()
        {
            ICar car = new CarProxy(new Driver(22));
            car.Drive();

            var weakRef = new WeakReference(car);
        }
    }
}
