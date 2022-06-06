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
        public int WarehouseID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public string Vehicle { get; set; }

        public Order(int OrderID_, int WarehouseID_, int ProductID_, int Amount_, string Vehicle_)
        {
            this.OrderID = OrderID_;
            this.WarehouseID = WarehouseID_;
            this.ProductID = ProductID_;
            this.Amount = Amount_;
            this.Vehicle = Vehicle_;
        }
        public Order()
        {

        }
    }
}
