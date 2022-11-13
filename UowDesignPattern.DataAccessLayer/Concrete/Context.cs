using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UowDesignPattern.EntityLayer.Concrete;

namespace UowDesignPattern.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-O6Q5UAT;database=DbDesignPatternUow; User Id=sa;Password=1234;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccountDetail> BankAccountDetails { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
    }
}
