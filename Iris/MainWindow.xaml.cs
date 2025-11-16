using Iris.Service;
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
        public UIElement CurrentPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CurrentPage = HomePage;
        }

        private void OpenShortcuts(object sender, RoutedEventArgs e) => OpenPage(ShortcutsPage, "RACCOURCIS");
        private void OpenHome(object sender, RoutedEventArgs e) => OpenPage(HomePage, "ACCUEIL");
        private void OpenChatGPT(object sender, RoutedEventArgs e) => OpenPage(ChatGPTPage, "CHATGPT");
        private void OpenMonitorEogend(object sender, RoutedEventArgs e) => OpenPage(MonitorEogendPage, "UPTIME EOGEND");
        private void OpenMonitorPerso(object sender, RoutedEventArgs e) => OpenPage(MonitorPersoPage, "UPTIME PERSONNEL");

        private void OpenPage(UIElement page, string titlePage)
        {
            TitleLabel.Content = "IRIS - " + titlePage;
            CurrentPage.Visibility = Visibility.Collapsed;
            page.Visibility = Visibility.Visible;
            CurrentPage = page;
            MenuToggleButton.IsChecked = false;
        }
    }
}