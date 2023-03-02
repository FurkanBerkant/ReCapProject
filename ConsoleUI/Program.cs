using Business.Concrete;
using DataAccess.Concretes.EntityFramework;
using Entites.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Customer customer1 = new Customer { CompanyName = "Kodlama.Io" };
            // CustomerManager customerManager = new(new EfCustomerDal());
            // customerManager.Add(customer1);
            Brand brand1 = new Brand();
            brand1.Name = "Mercedes";
            BrandManager brandManager = new(new EfBrandDal());
            brandManager.Add(brand1);

            var result = brandManager.GetAll();
            if (result.Succes)
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.Name);
                }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}