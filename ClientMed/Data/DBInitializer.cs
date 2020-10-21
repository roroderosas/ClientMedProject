using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientMed.Models;


namespace ClientMed.Data
{
    public static class DBInitializer
    {
        public static void Initialize(MedCalContext context)
        {
            context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return;
            }

            var clients = new Client[]
            {
                new Client{LastName="Test1", FirstMidName="Test1",Birthday=DateTime.Parse("2001-01-01"),MedicalHistory="test test test test test"},
                new Client{LastName="Test2", FirstMidName="Test2",Birthday=DateTime.Parse("2002-01-01"),MedicalHistory="test2 test2 test2 test2 test2"},
                new Client{LastName="Test3", FirstMidName="Test3",Birthday=DateTime.Parse("2003-01-01"),MedicalHistory="test3 test3 test3 test3 test3"}
            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

        }
    }
}
