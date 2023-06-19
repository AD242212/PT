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
            UserModel user = new UserModel(_mainViewModel.logic, _mainViewModel.NewUsername, _mainViewModel.NewPassword, 0);
            user.add_user();
            _mainViewModel.RefreshUsers();
        }
    }
}
