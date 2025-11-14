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

namespace Iris.Widget
{
    /// <summary>
    /// Logique d'interaction pour ShortcutWidget.xaml
    /// </summary>
    public partial class ShortcutWidget : UserControl
    {
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register("DisplayName", typeof(string), typeof(ShortcutWidget), new PropertyMetadata(OnPropertiesChangeCallback));
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(ShortcutWidget), new PropertyMetadata(OnPropertiesChangeCallback));
        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register("Url", typeof(string), typeof(ShortcutWidget), new PropertyMetadata(string.Empty));

        private static void OnPropertiesChangeCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is ShortcutWidget widget)
                widget.UpdateData();
        }

        public required string DisplayName
        {
            get => (string)GetValue(DisplayNameProperty);
            set => SetValue(DisplayNameProperty, value);
        }
        public required string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }
        public required string Url
        {
            get => (string)GetValue(UrlProperty);
            set => SetValue(UrlProperty, value);
        }


        public ShortcutWidget()
        {
            InitializeComponent();

            TitleLabel.Text = DisplayName;
            DescriptionLabel.Text = Description;
        }

        public void OpenUrl(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = Url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible d'ouvrir l'URL : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateData()         
        {
            TitleLabel.Text = DisplayName;
            DescriptionLabel.Text = Description;
        }
    }
}
