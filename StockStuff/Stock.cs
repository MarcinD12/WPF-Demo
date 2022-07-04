using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace WPF_App
{
	[Keyless]
	public class Stock1
	{
		
		public int ProductID { get; set; }
		public int Amount { get; set; }
		
		public int ShopId { get; set; }
		

		public Stock1(int ProductID_, int Amount_, int ShopID_)
		{
			
			this.ProductID = ProductID_;
			this.Amount = Amount_;
			this.ShopId = ShopID_;
		}
        public Stock1()
        {

        }
	}
}
