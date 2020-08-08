using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Models
{
    public class Context : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public Context()
        {
            if (!Database.CanConnect())
            {
                Database.EnsureCreated();
                Contacts.Add(new Contact(
                    "Ivan",
                    "Ivanov",
                    "ivan@mail.ru",
                    "8-999-000-11-22"
                ));
                Contacts.Add(new Contact(
                    "Petr",
                    "Petrov",
                    "petr@mail.ru",
                    "8-999-000-11-22"
                ));
                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite(@"Data Source=Contacts.db");
        }
    }
}
