using Iris.Model.UptimeKuma;
using Iris.Widget;
using System;
using System.Collections.Generic;
using System.Security.Policy;
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

namespace Iris.Widget
{
    /// <summary>
    /// Logique d'interaction pour UptimeWidget.xaml
    /// </summary>
    public partial class UptimeWidget : UserControl
    {
        private readonly UptimeMonitorResponse _monitor;

        public UptimeWidget(UptimeMonitorResponse monitor)
        {
            InitializeComponent();
            _monitor = monitor;

            TitleLabel.Text = monitor.Monitor.Name;
            UptimeLabel.Text = $"Type : {monitor.Monitor.Type} - Uptime: {monitor.Uptime * 100}% - Dernier Etat : {monitor.Heartbeats[^1].Status}";
            if (monitor.Monitor.SendUrl != 1 || monitor.Monitor.Url is null)
                UrlButton.IsEnabled = false;
        }

        public void OpenUrl(object sender, RoutedEventArgs e)
        {
            if (_monitor.Monitor.Url is null)
                return;

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = _monitor.Monitor.Url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible d'ouvrir l'URL : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
