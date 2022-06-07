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
    /// Interaction logic for EditItemWindow.xaml
    /// </summary>
    public partial class EditItemWindow : Window
    {
        public EditItemWindow()
        {
            InitializeComponent();
            productTypeEdit.ItemsSource = Product.Types;

        }
        public Product productToEdit { get; set; }


        private void productTypeEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productToEdit.Type = productTypeEdit.ToString();
        }

        private void productNameEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            productToEdit.ProductName = productNameEdit.ToString();
        }

        private void productPriceEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal res;
            bool isnumeric = Decimal.TryParse(productPriceEdit.Text, out res);
            if (isnumeric)
            {
                productToEdit.Price = res;
            }
            else
            {
                MessageBox.Show("REEEE1");
            }
        }

        private void searchItem_Click(object sender, RoutedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                productToEdit = db.Products.Find(int.Parse(idToEdit.Text));
                productNameEdit.Text = productToEdit.ProductName.ToString();
                productPriceEdit.Text = productToEdit.Price.ToString();
                productTypeEdit.SelectedItem = productToEdit.Type.ToString();
                
            }
        }

        private void applyChanges_Click(object sender, RoutedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                //nie działa

                //db.Update(productToEdit);
                //db.SaveChanges(); 
                //db.Entry(productToEdit).CurrentValues.SetValues(productToEdit);
            }
        }
    }
}
