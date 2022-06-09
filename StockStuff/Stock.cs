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
	[Keyless]
	public class Stock
	{
		
		public int ProductID { get; set; }
		public int Amount { get; set; }
		
		public int ShopId { get; set; }

		public Stock(int ProductID_, int Amount_, int ShopID_)
		{
			
			this.ProductID = ProductID_;
			this.Amount = Amount_;
			this.ShopId = ShopID_;
		}
        public Stock()
        {

        }
	}
}
