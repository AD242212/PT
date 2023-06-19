using Presentation.Model;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for PopUpItem.xaml
    /// </summary>
    public partial class PopUpItem : Window
    {
        public PopUpItem(IItemModel item)
        {
            InitializeComponent();
            InitializePopupContent(item);
        }

        private void InitializePopupContent(IItemModel item)
        {
            var table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Price");
            table.Columns.Add("In Stock");
            
            table.Rows.Add(item.name, item.price, item.nums_in_stock);
            
            var dataGrid = new DataGrid
            {
                AutoGenerateColumns = true,
                ItemsSource = table.DefaultView
            };
            
            Content = dataGrid;
        }
    }

}
