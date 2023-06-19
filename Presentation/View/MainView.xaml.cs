using Data.Implementation;
using Logic.Implementation;
using Presentation.Model;
using Presentation.ViewModel;
using System.Windows.Controls;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            string DatabasePath = $@"C:\Users\Artur\Source\Repos\PT3.1\PT_Testing\Shop.mdf";
            BusinessLogic logic = new BusinessLogic(new DataHandler(@$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DatabasePath};Integrated Security = True;"));
            DataContext = new MainViewModel(logic);
        }

        private void ListViewItem_User(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is ListViewItem listViewItem && listViewItem.IsSelected)
            {
                // Get the selected user
                var selectedUser = listViewItem.DataContext as IUserModel;

                if (selectedUser != null)
                {
                    var popupWindow = new PopUpUser(selectedUser);
                    popupWindow.ShowDialog();
                }
            }
        }

        private void ListViewItem_Item(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is ListViewItem listViewItem && listViewItem.IsSelected)
            {
                // Get the selected item
                var selectedItem = listViewItem.DataContext as IItemModel;

                if (selectedItem != null)
                {
                    // Create and show the popup window
                    var popupWindow = new PopUpItem(selectedItem);
                    popupWindow.ShowDialog();
                }
            }
        }
    }
}
