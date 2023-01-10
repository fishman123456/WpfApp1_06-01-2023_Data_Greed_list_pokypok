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
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<Product> _toData_list;
        private FileIO _FileIO_fileIO;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _FileIO_fileIO = new FileIO(PATH);
          
            try
            {
                _toData_list = _FileIO_fileIO.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            //_toData_list = new BindingList<Product>()
            //{
            //    new Product() { Name = "Овощи" , Count =2, IsBuy = true},
            //    new Product() { Name = "Фрукты" , Count =10, IsBuy = true}

            //};
            productGrid.ItemsSource = _toData_list;
            _toData_list.ListChanged += _toData_list_ListChanger;
        }
        // метод для генерирования события при изменении таблици данных
        private void _toData_list_ListChanger(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType==ListChangedType.ItemAdded||
                e.ListChangedType==ListChangedType.ItemDeleted||
                e.ListChangedType==ListChangedType.ItemChanged)
            {
                try
                {
                    _FileIO_fileIO.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();   
                }
            }
            ////throw new NotImplementedException();
            //switch(e.ListChangedType)
            //{
            //    case ListChangedType.ItemChanged:
            //        break;
            //}
       }

        private void productGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
