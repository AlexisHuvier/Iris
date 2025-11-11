using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Iris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserControl CurrentPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CurrentPage = HomePage;
        }

        private void OpenShortcuts(object sender, RoutedEventArgs e) => OpenPage(ShortcutsPage);
        private void OpenHome(object sender, RoutedEventArgs e) => OpenPage(HomePage);

        private void OpenPage(UserControl page)
        {
            CurrentPage.Visibility = Visibility.Collapsed;
            page.Visibility = Visibility.Visible;
            CurrentPage = page;
            MenuToggleButton.IsChecked = false;
        }
    }
}