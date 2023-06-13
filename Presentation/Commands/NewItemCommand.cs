using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model;
using Presentation.ViewModel;

namespace Presentation.Commands
{
    internal class NewItemCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        public NewItemCommand(MainViewModel main)
        {
            _mainViewModel = main;
        }
        public override void Execute(object? parameter)
        {
            UserModel user = new UserModel(_mainViewModel.logic,_mainViewModel.NewUsername, _mainViewModel.NewPassword, 0);
        }
    }
}
