using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_App.Orderstuff
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {       
        /// <summary>
        /// Initialization of order page, filling combobox with available values from DB
        /// </summary>
        public OrderPage()
        {
            InitializeComponent();
            using (Connection db = new Connection(Connection.connectionString))
            {
                var prods = (from x in db.Products select x.ProductName).ToList();
                productselection.ItemsSource = prods;
                var shops = (from d in db.Shop select d.City).ToList();
                shopselection.ItemsSource = shops;
            }


        }
        /// <summary>
        /// variables used to hold selected IDs, and amount
        /// </summary>
        private int selprod;
        private int selshop;
        private int amount;
        /// <summary>
        /// By clicking "Place new order" new Order object is created with values stored in holded variables
        /// In DB.Stock stock of selected Product in Selected shop is updated 
        /// </summary>     
        private void newOrder_Click(object sender, RoutedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {

                db.Add(new Order(db.Orders.Max(x => x.OrderID + 1), selshop, selprod, amount, DateTime.Now));
                var stockUpdate = (from x in db.Stock
                                   where x.ProductID == selprod && x.ShopId == selshop
                                   select x).FirstOrDefault();
                stockUpdate.Amount -= amount;
               // MessageBox.Show(stockUpdate.Amount.ToString());
                if (stockUpdate.Amount>=0)
                {
                    db.Stock.Update(stockUpdate);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("There is no given amount in stock!");
                }

            }
            //OrderFrame.Content = new NewOrderPage();
        }
        /// <summary>
        /// by selecting product.Name "selprod" is assigned with proper ProductID  
        /// </summary>   
        private void productselection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selprod = productselection.SelectedIndex + 1;
            //MessageBox.Show(selprod.ToString());
        }
        /// <summary>
        ///  by selecting Shop.City "selshop" is assigned with proper ShopId
        /// </summary>       
        private void shopselection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selshop = shopselection.SelectedIndex + 1;
        }

        /// <summary>
        /// with every text change in selAmount TextBox amount is updated with new value
        /// </summary>
        private void selAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            amount = int.Parse(selAmount.Text);
           // MessageBox.Show(amount.ToString());
        }
        /// <summary>
        /// By clicking "Show all orders" allorders DataGrid is filled with all records from DB.Orders
        /// </summary>       
        private void allOrders_Click(object sender, RoutedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                allorders.ItemsSource = db.Orders.ToList();
            }
        }
    }
}
