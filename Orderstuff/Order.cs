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
        public DateTime Date { get; set; }
        /// <summary>
        /// Constructor of Order class instance
        /// </summary>
        /// <param name="OrderID_"> ID of order</param>
        /// <param name="ShopId"> ID of shop where order is placed</param>
        /// <param name="ProductID_"> Id of Product</param>
        /// <param name="Amount_"> Amount of ordered item</param>
        /// <param name="DateTime_"> Date when order is placed</param>
        public Order(int OrderID_, int ShopId, int ProductID_, int Amount_, DateTime DateTime_)
        {
            this.OrderID = OrderID_;
            this.ShopId = ShopId;
            this.ProductID = ProductID_;
            this.Amount = Amount_;
            this.Date = DateTime_;
            
        }
        public Order()
        {

        }
    }
}
