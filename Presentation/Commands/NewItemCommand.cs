using Presentation.Model;
using Presentation.ViewModel;
using System;

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
            ItemModel item = new ItemModel(_mainViewModel.logic, _mainViewModel.NewName, float.Parse(_mainViewModel.NewPrice), Int32.Parse(_mainViewModel.NewInStock));
            item.add_item();
            _mainViewModel.RefreshItems();
        }
    }
}
