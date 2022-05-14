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
using Logistics_project;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void BtnClicked();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //private void Clicked(object sender, RoutedEventArgs e,BtnClicked btnClicked)
        //{
        //    btnClicked(); 
        //}

        private void BTNAddVehicle(object sender, RoutedEventArgs e)
        {
            string VEHID = VehID.Text;
            int  status = Logistics_project.Dupa.Send(VEHID);
            if (status==1)
            {
                MessageBox.Show("error");
            }
            else
            {
                MessageBox.Show("added");
            }
            

        }

        private void BTNRemoveVehicle(object sender, RoutedEventArgs e)
        {
            int status = Dupa.Remove(VehID.Text);
            if (status==1)
            {
                MessageBox.Show("nope");

            }
            else
            {
                MessageBox.Show("removed");
            }
        }

        
    }
}
