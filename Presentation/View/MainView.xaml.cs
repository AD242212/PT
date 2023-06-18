using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Data.Implementation;
using Logic.Implementation;
using Presentation.ViewModel;

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
    }
}
