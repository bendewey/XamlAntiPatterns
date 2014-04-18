using System.Windows.Controls;

namespace XamlAntiPatterns._5_UserControl
{
    /// <summary>
    /// Interaction logic for AddressControl.xaml
    /// </summary>
    public partial class AddressControl : UserControl
    {
        public object GroupHeader
        {
            get { return GroupContainer.Header; }
            set { GroupContainer.Header = value; }
        }

        public AddressControl()
        {
            InitializeComponent();
        }
    }
}
