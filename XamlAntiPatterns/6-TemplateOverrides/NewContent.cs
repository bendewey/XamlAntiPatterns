using System.Windows;
using System.Windows.Controls;

namespace XamlAntiPatterns._6_TemplateOverrides
{
    public class NewContent : ContentControl
    {
        public NewContent()
        {
            DefaultStyleKey = typeof(NewContent);
        }
        
        public string EarmarkText
        {
            get { return (string)GetValue(EarmarkTextProperty); }
            set { SetValue(EarmarkTextProperty, value); }
        }

        public static readonly DependencyProperty EarmarkTextProperty =
            DependencyProperty.Register("EarmarkText", typeof(string), 
                    typeof(NewContent), new PropertyMetadata(null));
    }
}
