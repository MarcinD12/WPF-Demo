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
    /// Interaction logic for NewProductWindow.xaml
    /// </summary>
    public partial class NewProductWindow : Window
    {
        public NewProductWindow()
        {
            InitializeComponent();
            productList.ItemsSource = Product.Types;
        }
        public string selectedType { get; set; }
        private void productList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedType = productList.SelectedItem.ToString();
            //MessageBox.Show(selectedType);
        }
        private async void  ProductAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (prodNameInp.Text!=""&&(prodPriceInp!=null||int.Parse(prodPriceInp.Text)<=0)&&selectedType!="")
            {
                using (Connection db = new Connection(Connection.connectionString))
                {
                    db.Add(new Product(db.Products.Max(x => x.ProductID) + 1, prodNameInp.Text.ToString(), selectedType, decimal.Parse(prodPriceInp.Text)));
                    await db.SaveChangesAsync();                                                                                                                                    //ASYNC
                    // db.SaveChanges();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("REEEEEEEEE");
            }
        
        }

 
        
    }

}
