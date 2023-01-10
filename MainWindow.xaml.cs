using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1_06_01_2023_Data_Greed_list_pokypok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<Product> _toData;

        public MainWindow()
        {
            InitializeComponent();
          
        }

   

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _toData = new BindingList<Product>()
            {
                new Product() { Name = "Овощи" , Count =2, IsBuy = true},
                new Product() { Name = "Фрукты" , Count =10, IsBuy = true}

            };
            productGrid.ItemsSource= _toData;
            }

        private void productGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
