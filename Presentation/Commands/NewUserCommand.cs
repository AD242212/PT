using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model;
using Presentation.ViewModel;

namespace Presentation.Commands
{
    internal class NewUserCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public NewUserCommand(MainViewModel main)
        {
            _mainViewModel = main;
        }
        public override void Execute(object? parameter)
        {
            ItemModel user = new ItemModel(_mainViewModel.NewName, float.Parse(_mainViewModel.NewPrice), Int32.Parse(_mainViewModel.NewInStock));
        }
    }
}
