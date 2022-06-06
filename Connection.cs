using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WPF_App
{
    
    public class Connection :DbContext
    {
        public static string connectionString = @"Data Source=DESKTOP-CPTE25K\SQLEXPRESS;Initial Catalog=WpfAppDb;Integrated Security=True";
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public string ConnectionString { get; }
        public Connection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }
}
