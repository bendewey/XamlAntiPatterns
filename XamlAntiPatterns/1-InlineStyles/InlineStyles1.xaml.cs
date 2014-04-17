using System;
using System.Windows;
using System.Windows.Controls;

namespace XamlAntiPatterns._1_InlineStyles
{
    /// <summary>
    /// Interaction logic for InlineStyles1.xaml
    /// </summary>
    public partial class InlineStyles1 : Page
    {
        public InlineStyles1()
        {
            InitializeComponent();
        }

        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            var uri = (string)((FrameworkElement)sender).Tag;
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }
    }
}
