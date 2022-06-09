using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App
{
	public class Stock
	{
		public int ProductID { get; set; }
		public int Amount { get; set; }
		public int ShopId { get; set; }

		public Stock(int ProductID_, int Amount_, int PickUpID_)
		{
			this.ProductID = ProductID_;
			this.Amount = Amount_;
			this.ShopId = PickUpID_;
		}
	}
}
