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
        private int selprod;
        private int selshop;
        private int amount;
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

        private void productselection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selprod = productselection.SelectedIndex + 1;
            //MessageBox.Show(selprod.ToString());
        }

        private void shopselection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selshop = shopselection.SelectedIndex + 1;
        }


        private void selAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            amount = int.Parse(selAmount.Text);
           // MessageBox.Show(amount.ToString());
        }

        private void allOrders_Click(object sender, RoutedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                allorders.ItemsSource = db.Orders.ToList();
            }
        }
    }
}
