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
        /// <summary>
        /// initialization of EditItemWindow
        /// Filling productTypeEdit ComboBox with available product types
        /// </summary>
        public EditItemWindow()
        {
            InitializeComponent();
            productTypeEdit.ItemsSource = Product.Types;

        }
        private Product productToEdit { get; set; }
        
        private void productTypeEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productToEdit.Type = productTypeEdit.ToString();
        }
        /// <summary>
        /// serching for product with set id, and saving it into "productToEdit"
        /// </summary>       
        private void searchItem_Click(object sender, RoutedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                productToEdit = db.Products.Find(int.Parse(idToEdit.Text));
                productNameEdit.Text = productToEdit.ProductName.ToString();
                productPriceEdit.Text = productToEdit.Price.ToString();
                productTypeEdit.SelectedItem = productToEdit.Type;
                //productTypeEdit.SelectedItem = productToEdit.Type.ToString();
                
            }
        }
        /// <summary>
        /// by clicking "Apply Change" btn set values are assigned to selected item, and its saved to DB
        /// </summary>
        private async void  applyChanges_Click(object sender, RoutedEventArgs e)
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                productToEdit.ProductName = productNameEdit.Text;
                productToEdit.Price = decimal.Parse(productPriceEdit.Text);
                productToEdit.Type = productTypeEdit.SelectedItem.ToString();
                
                db.Update(productToEdit);
                //db.SaveChanges(); 
                await db.SaveChangesAsync();
                this.Hide();
            }
        }
    }
}
