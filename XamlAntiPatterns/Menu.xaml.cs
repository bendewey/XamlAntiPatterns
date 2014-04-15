using System;
using System.Windows;
using System.Windows.Controls;

namespace XamlAntiPatterns
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            var uri = (string)((FrameworkElement)sender).Tag;
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
                scrollviewer.LineLeft();
            else
                scrollviewer.LineRight();
            e.Handled = true;
        }
    }
}
