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
using WPF_App;
namespace WPF_App.StockStuff
{
    /// <summary>
    /// Interaction logic for StockDataPage.xaml
    /// </summary>
    public partial class StockDataPage : Page
    {
        //private Microsoft.EntityFrameworkCore.DbSet<Stock> allproductData { get; set; }
        public StockDataPage()
        {

            InitializeComponent();
            using(Connection db = new Connection(Connection.connectionString))
            {

                        
                var stockData = from s in db.Stock join p in db.Products on s.ProductID equals p.ProductID join xd in db.Shop on s.ShopId equals xd.ShopId orderby s.ProductID select new { xd.ShopId,xd.City,s.ProductID, s.Amount, p.ProductName, p.Price, } ;
                stockData.ToList();
                

                int chuj = db.Stock.Count();
                MessageBox.Show(chuj.ToString());
                StockDataGrid.ItemsSource = stockData.ToList();
 
            }
        }
    }
}
