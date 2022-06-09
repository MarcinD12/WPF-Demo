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

namespace WPF_App.StockStuff
{
    /// <summary>
    /// Interaction logic for StockManipulation.xaml
    /// </summary>
    public partial class StockManipulation : Page
    {

        public StockManipulation()
        {

            InitializeComponent();
            using (Connection db = new Connection(Connection.connectionString))
            {

                var products = from a in db.Products
                               select new { a.ProductID, a.ProductName };

                productComboBox.ItemsSource = products.ToList();

            }

        }


        public int prodid { get; set; }

        public int shopiddd { get; set; }
        private void productComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("xd?");
            using (Connection db = new Connection(Connection.connectionString))
            {
                int index = productComboBox.SelectedIndex+1;
                prodid = index;
                //MessageBox.Show(index.ToString());
                var avshops = from x in db.Stock
                              join d in db.Shop on x.ShopId equals d.ShopId
                              where x.ProductID == index
                              select new { x.ShopId, d.City, d.StreetAdress };

                shopCombobox.ItemsSource = avshops.ToList();
                shopCombobox.Visibility = Visibility.Visible;
            }
        }

        private void shopCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
               
             

                //MessageBox.Show(shopiddd.ToString() + " " + prodid.ToString());
                var stock = (from x in db.Products
                            join d in db.Stock on x.ProductID equals d.ProductID
                            where x.ProductID == productComboBox.SelectedIndex +1&& d.ShopId == shopCombobox.SelectedIndex+1
                            select d.Amount);
               // MessageBox.Show(shopCombobox.SelectedItem.ToString());
                

                currentStock.Text = stock.ToString() ;

                          }


            //currentStock.Text =
        }
    }
}
