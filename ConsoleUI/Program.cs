using Business.Concrete;
using DataAccess.Concretes.EntityFramework;
using Entites.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal()); 
            carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 100, 
                Description = "Audi A4", ModelYear = 2010 });
            Console.WriteLine(carManager.GetAll());
            foreach (var car in carManager.GetAll())

            {
                Console.WriteLine(car.Description);
            }
        }
    }
}