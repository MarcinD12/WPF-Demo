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
    /// Interaction logic for DeleteItemWindow.xaml
    /// </summary>
    public partial class DeleteItemWindow : Window
    {
        public DeleteItemWindow()
        {
            InitializeComponent();
        }
        private  int idToDelete{ get; set; }
        private  void Button_Click(object sender, RoutedEventArgs e) ///tu async nie działa
        {
            using (Connection db = new Connection(Connection.connectionString))
            {
                if (db.Products.Any(x=>x.ProductID==2)&&IdToDelete.Text!=null)
                {
                    var toDelete = db.Products.Find(idToDelete);
                    db.Remove(toDelete);
                    
                    //db.SaveChangesAsync();
                    db.SaveChanges();
                    this.Hide();
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            idToDelete = int.Parse(IdToDelete.Text);
        }
    }
}
