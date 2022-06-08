using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ShopId { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        

        public Order(int OrderID_, int ShopId, int ProductID_, int Amount_)
        {
            this.OrderID = OrderID_;
            this.ShopId = ShopId;
            this.ProductID = ProductID_;
            this.Amount = Amount_;
            
        }
        public Order()
        {

        }
    }
}
