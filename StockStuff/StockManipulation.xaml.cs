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
                               select a;

                // productComboBox.ItemsSource = products.ToList();

                productComboBox.ItemsSource = products.ToList();
                shopCombobox.ItemsSource = (from b in db.Shop
                                           select b).ToList();

            }

        }
        public int prodid { get; set; }

        public Product selprod { get; set; }

        public int selShopId { get; set; }
        private void productComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            using (Connection db = new Connection(Connection.connectionString))
            {
                selprod = db.Products.Find(productComboBox.SelectedIndex+1);
                prodid = selprod.ProductID;
                
                MessageBox.Show(selprod.ProductID.ToString());
                shopCombobox.Visibility = Visibility.Visible;
               
            }
        }
        
        private void shopCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                selShopId = shopCombobox.SelectedIndex+1;
              MessageBox.Show(selShopId.ToString());
                
                //MessageBox.Show(selprod.ProductID + " " + selShopId);
                var curstock = (from x in db.Stock
                          where x.ProductID == prodid && x.ShopId == selShopId
                          select x).FirstOrDefault();

                //MessageBox.Show(curstock.Amount.ToString());
                curentstocks.Text = curstock.Amount.ToString();
            }

        }

        private void applyChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                Stock1 stockToChange = (from x in db.Stock
                                       where x.ProductID == prodid && x.ShopId == selShopId
                                       select x).FirstOrDefault();
                stockToChange.Amount = int.Parse(newStock.Text);
                db.Update(stockToChange);
                db.SaveChanges();
                MessageBox.Show("Stock Updated");
            }
        }
    }
}
