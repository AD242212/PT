using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Logic.API;
using Presentation.Commands;
using Presentation.Model;

namespace Presentation.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public List<String> Items
        {
            get { return new List<String> { "One", "Two", "Three" }; }
        }
        
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
            get
            {
                return _newusername;
            }
            set
            {
                _newusername = value;
                OnPropertyChange(nameof(NewUsername));
            }
        }

        public string NewPassword
        {
            get
            {
                return _newpassword;
            }
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
            get
            {
                return _newname;
            }
            set
            {
                _newname = value;
                OnPropertyChange(nameof(NewName));
            }
        }

        public string NewPrice
        {
            get
            {
                return _newprice;
            }
            set
            {
                _newprice = value;
                OnPropertyChange(nameof(NewPrice));
            }
        }

        public string NewInStock
        {
            get
            {
                return _newinstock;
            }
            set
            {
                _newinstock = value;
                OnPropertyChange(nameof(NewInStock));
            }
        }


        public ICommand SubmitNewUser
        {
            get;
        }

        public ICommand SubmitNewItem{ get; }

        public MainViewModel(IBusinessLogic logic)
        {
            this.logic = logic;
            // SubmitNewUser = new NewUserCommand(this);
            // SubmitNewItem = new NewItemCommand(this);
        }

        public void addUser()
        {
            UserModel usr = new UserModel(logic, NewUsername, NewPassword,1);
            usr.add_user();

        }

        public void addItem()
        {
            ItemModel model = new ItemModel(logic,NewName,(float) Int32.Parse(NewPrice),Int32.Parse(NewInStock));
            model.add_item();
        }
        
    }
}
