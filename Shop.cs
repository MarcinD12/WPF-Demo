using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App
{
	public class Shop
	{
		
		public int ShopId { get; set; }
		public string StreetAdress { get; set; }
		public string City { get; set; }
		

		public Shop(int ShopId_, string StreetAdress_, string City_)
		{
			this.ShopId = ShopId_;
			this.StreetAdress = StreetAdress_;
			this.City = City_;
			
		}
        public Shop()
        {

        }
	}
}
