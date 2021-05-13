using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Homework3.Models;

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var users = new List<Models.User>();

            users.Add(new User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;

        }
        private void uxList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SortDescription match;

            GridViewColumnHeader columnClicked = e.OriginalSource as GridViewColumnHeader;
            string columnHeaderText = columnClicked.Content.ToString();

            // sort the ListView column based on this column data
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);

            // Remove all SortDescriptions first
            while (view.SortDescriptions.Any<SortDescription>())
            {
                match = view.SortDescriptions.FirstOrDefault<SortDescription>();
                view.SortDescriptions.Remove(match);
            }
            view.SortDescriptions.Add(new SortDescription(columnHeaderText, ListSortDirection.Ascending));

        }
    }
}
