using Iris.Service;
using Iris.Widget;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Iris.Page
{
    /// <summary>
    /// Logique d'interaction pour UptimePage.xaml
    /// </summary>
    public partial class UptimePage : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(UptimePage), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty SlugProperty =
            DependencyProperty.Register("Slug", typeof(string), typeof(UptimePage), new PropertyMetadata(string.Empty));

        public required string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public required string Slug
        {
            get => (string)GetValue(SlugProperty);
            set => SetValue(SlugProperty, value);
        }

        public UptimePage()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new();
            dispatcherTimer.Tick += new EventHandler((obj, e) => ReloadPage());
            dispatcherTimer.Interval = TimeSpan.FromSeconds(10);
            dispatcherTimer.Start();
        }


        public void ReloadPage(object sender, RoutedEventArgs e) => ReloadPage();

        public void ReloadPage()
        {
            UptimeWidgetsContainer.Items.Clear();
            LastReload.Text = $"Dernier Reload : {DateTime.Now}";
            var monitors = UptimeKumaService.CallUptime(Slug);
            foreach (var monitor in monitors)
            {
                var widget = new UptimeWidget(monitor);
                UptimeWidgetsContainer.Items.Add(widget);
            }
        }
    }
}
