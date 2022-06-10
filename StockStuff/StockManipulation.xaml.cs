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
        //public List chuj { get; set; }
        public StockManipulation()
        {

            InitializeComponent();
            using (Connection db = new Connection(Connection.connectionString))
            {

                var products = from a in db.Products
                               select new { a.ProductID, a.ProductName };

                
                productComboBox.ItemsSource = products.ToList();
                shopCombobox.ItemsSource = (from b in db.Shop
                                           select new { b.ShopId, b.City }).ToList();

            }

        }

        public Shop avShop { get; set; }
        public int prodid { get; set; }

        public Product selprod { get; set; }

        public int selShopId { get; set; }
        private void productComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("xd?");
            using (Connection db = new Connection(Connection.connectionString))
            {
                selprod = db.Products.Find(productComboBox.SelectedIndex+1);
               
                shopCombobox.Visibility = Visibility.Visible;
                //chuj = shopxd.ToList();
            }
        }
        
        private void shopCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                selShopId = shopCombobox.SelectedIndex+1;
                MessageBox.Show(selprod.ProductID + " " + selShopId);
                var xd = (from x in db.Stock
                          where x.ProductID == selprod.ProductID && x.ShopId == selShopId
                          select x.Amount).FirstOrDefault();
                MessageBox.Show(xd.ToString());

                //currentStock.Text = xd.ToString();

                curentstocks.Text = xd.ToString();
            }


            //currentStock.Text =
        }
    }
}
