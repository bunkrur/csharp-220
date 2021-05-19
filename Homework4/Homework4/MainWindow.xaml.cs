
using System.Windows;
using System.Windows.Controls;
using Homework4;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ZipCode zipCode = new ZipCode();
        public MainWindow()
        {
            InitializeComponent();
            AddressBox.DataContext = zipCode;
            
        }
        private void ZipCodeChanged(object sender, TextChangedEventArgs e)
        {
            Submit.IsEnabled = zipCode.ValidZipCode;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
