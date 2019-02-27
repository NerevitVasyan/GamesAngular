using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=testdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game[]
                {
                    new Game{ Name = "Witcher 3", Developer ="CdProject Red",Year = 2015,Id=1},
                    new Game{ Name = "TES V - Skyrim", Developer ="Bethesda",Year = 2011,Id=2},
                    new Game{ Name = "GTA V", Developer ="Rockstar",Year = 2015,Id=3},
                    new Game{ Name = "Kingdom Come: Deliverance", Developer ="Warhorse",Year = 2018,Id=4}
                });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Games { get; set; }
    }
}
