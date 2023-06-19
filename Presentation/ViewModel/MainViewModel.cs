using Logic.API;
using Presentation.Commands;
using Presentation.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Data.API;

namespace Presentation.ViewModel
{
    public partial class PopupWindow : Window
    {
       
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public IBusinessLogic logic;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _newusername;
        private string _newpassword;

        public string NewUsername
        {
            get { return _newusername; }
            set
            {
                _newusername = value;
                OnPropertyChange(nameof(NewUsername));
            }
        }

        public string NewPassword
        {
            get { return _newpassword; }
            set
            {
                _newpassword = value;
                OnPropertyChange(nameof(NewPassword));
            }
        }

        private string _newname;
        private string _newprice;
        private string _newinstock;

        public string NewName
        {
            get { return _newname; }
            set
            {
                _newname = value;
                OnPropertyChange(nameof(NewName));
            }
        }

        public string NewPrice
        {
            get { return _newprice; }
            set
            {
                _newprice = value;
                OnPropertyChange(nameof(NewPrice));
            }
        }

        public string NewInStock
        {
            get { return _newinstock; }
            set
            {
                _newinstock = value;
                OnPropertyChange(nameof(NewInStock));
            }
        }


        public ICommand SubmitNewUser { get; }

        public ICommand SubmitNewItem { get; }

        public ObservableCollection<IUserModel> _users =  new ObservableCollection<IUserModel>();

        public ObservableCollection<IUserModel> users
        {
            get { return _users; }
        }

        public ObservableCollection<IItemModel> _items = new ObservableCollection<IItemModel>();

        public ObservableCollection<IItemModel> items
        {
            get { return _items; }
        }

        public void RefreshUsers()
        {
            _users.Clear();

            foreach (var user in logic.get_users())
            {
                _users.Add(new UserModel(this.logic, user.username, user.password, user.balance));
            }
        }

        public void RefreshItems()
        {
            _items.Clear();

            foreach (var item in logic.get_items())
            {
                _items.Add(new ItemModel(this.logic, item.name, item.price, item.nums_in_stock));
            }
        }

        public MainViewModel(IBusinessLogic logic)
        {
            this.logic = logic;
            RefreshItems();
            RefreshUsers();
            SubmitNewUser = new NewUserCommand(this);
            SubmitNewItem = new NewItemCommand(this);
        }
    }
}