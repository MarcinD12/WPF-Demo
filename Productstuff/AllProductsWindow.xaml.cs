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
using System.Windows.Shapes;

namespace WPF_App.Productstuff
{
    /// <summary>
    /// Interaction logic for AllProductsWindow.xaml
    /// </summary>
    public partial class AllProductsWindow : Window
    {
        public AllProductsWindow()
        {
            InitializeComponent();

            
            using (Connection db = new Connection(Connection.connectionString))
            {
                
                allproductData = db.Products;
                //foreach (var item in allproductData)
                //{
                //    MessageBox.Show(item.ProductName);
                //}
                ProductsGrid.ItemsSource = allproductData.ToList();
            }
            
        }
       private Microsoft.EntityFrameworkCore.DbSet<Product> allproductData { get; set; }

    }
}
