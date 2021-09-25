using CustomerService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CustomerService.Data
{
    public static class DbDataInitializer
    {
        public static void SeedDatabase(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
            try
            {
                Initialize(appContext);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Initialize(CustomerDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any() || context.Adresses.Any())
            {
                Console.WriteLine("---<<<<< Already initialized database ! >>>>---");
                return;
            }

            Console.WriteLine("---<<<<< Start initializing database ! >>>>---");

            var adresses = new Adress[]
            {
                new Adress { Street = "4 Rue des lilas d'espagne", City = "Courbevoie", Country = "France", ZipCode = 92400},
                new Adress { Street = "10 Avenue Liberland", City = "Ivry Sur Seine", Country = "France", ZipCode = 94200},
                new Adress { Street = "10 rue Victor Basg", City = "Argenteil", Country = "France", ZipCode = 95100}
            };

            foreach (var a in adresses)
            {
                context.Adresses.Add(a);
            }

            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{FirstName="Carson",LastName="Alexander", Email = "Carson.Alexander@gmail.com", PhoneNumber = "+33 769142107",
                Adress = context.Adresses.FirstOrDefault(a => a.ZipCode == 92400) },
                new Customer{FirstName="Meredith",LastName="Alonso", Email = "Meredith.Alonso@gmail.com", PhoneNumber = "+33 614210498",
                Adress = context.Adresses.FirstOrDefault(a => a.ZipCode == 94200) },
                new Customer{FirstName="Arturo",LastName="Anand", Email = "Arturo.Anand@gmail.com", PhoneNumber = "+33 765986324",
                Adress = context.Adresses.FirstOrDefault(a => a.ZipCode == 95100) }
            };

            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }

            context.SaveChanges();

            Console.WriteLine("---<<<<< End initializing database ! >>>>---");
        }
    }
}
