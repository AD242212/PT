using Presentation.Model;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for PopUpUser.xaml
    /// </summary>
    public partial class PopUpUser : Window
    {
        public PopUpUser(IUserModel user)
        {
            InitializeComponent();
            InitializePopupContent(user);
        }

        private void InitializePopupContent(IUserModel user)
        {
            var table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Balance");
            
            table.Rows.Add(user.username, user.balance);
            
            var dataGrid = new DataGrid
            {
                AutoGenerateColumns = true,
                ItemsSource = table.DefaultView
            };
            
            Content = dataGrid;
        }
    }

}
