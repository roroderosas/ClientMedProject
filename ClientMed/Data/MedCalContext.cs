using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientMed.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientMed.Data
{
    public class MedCalContext : DbContext
    {
        public MedCalContext(DbContextOptions<MedCalContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<MedCalendar> MedCalendars { get; set; }
        public DbSet<DayOfWk> DayOfWks { get; set; }
        public DbSet<DaySched> DayScheds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<MedCalendar>().ToTable("MedCalendar");
            modelBuilder.Entity<DayOfWk>().ToTable("DayOfWk");
            modelBuilder.Entity<DaySched>().ToTable("DaySched");
            
        }
    }
}
