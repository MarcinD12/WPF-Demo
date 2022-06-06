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

using Microsoft.EntityFrameworkCore;

namespace WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// https://codverter.com/src/sqltoclass
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //string connectionString = @"Data Source=DESKTOP-CPTE25K\SQLEXPRESS;Initial Catalog=WpfAppDb;Integrated Security=True";
            
            using (Connection db = new Connection(Connection.connectionString))
            {
                //try
                //{
                    
                    db.SaveChanges();
                //}
                //catch (Exception)
                //{

                //    MessageBox.Show("xD");
                //}//var x = db.Add
                
            }
        }

        private void ProductsWindow_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            //this.Visibility = Visibility.Hidden;
            productWindow.Show();
            MainFrame.Content = new ProductPage();
        }
    }
}
