using Business.Concrete;
using DataAccess.Concretes.EntityFramework;
using Entites.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { UserId = 1, CompanyName = "Kodlama.Io" };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(customer1);
            var result = customerManager.GetAll();
            if (result.Succes)
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}