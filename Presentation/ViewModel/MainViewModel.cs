using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.Commands;

namespace Presentation.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

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


        public ICommand SubmitNewUser { get; }

        public ICommand SubmitNewItem{ get; }

        public MainViewModel()
        {
            // SubmitNewUser = new NewUserCommand();
            // SubmitNewItem = new NewItemCommand();
        }
        
    }
}
