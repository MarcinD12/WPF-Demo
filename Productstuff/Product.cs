using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
namespace WPF_App
{
    public class Product
    {

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        

        public Product(int ProductID_, string ProductName_, string Type_, decimal Price_)
        {
            this.ProductID = ProductID_;
            this.ProductName = ProductName_;
            if (Types.Contains(Type_))
            {
                this.Type = Type_;
            }           
            this.Price = Price_;
            
        }
        public Product()
        {

        }

        public static List<string> Types = new List<string>() { "Engine","Exhaust system","Suspension","Brake system","Transmission","Electrical system","Accesories"}; //7 types

        

       
    }
}
