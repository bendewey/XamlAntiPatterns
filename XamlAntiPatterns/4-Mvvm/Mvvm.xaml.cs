using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace XamlAntiPatterns._4_Mvvm
{
    /// <summary>
    /// Interaction logic for Mvvm.xaml
    /// </summary>
    public partial class Mvvm : Page
    {
        public Mvvm()
        {
            InitializeComponent();

            // Good scenario of IoC
            var orderService = new OrderService();
            MvvmPanel.DataContext = new OrderViewModel(orderService);
        }

        public class OrderViewModel
        {
            private readonly IOrderService _orderService;

            public OrderViewModel(IOrderService orderService)
            {
                _orderService = orderService;

                Order = new Order()
                {
                    BillingAddress = new Address(),
                    ShippingAddress = new Address()
                };
            }

            public Order Order { get; set; }

            public void Process()
            {
                _orderService.Process(Order);
            }
        }

        public class Order
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public Address BillingAddress { get; set; }
            public Address ShippingAddress { get; set; }
        }

        public class Address
        {
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
        }

        public interface IOrderService
        {
            void Process(Order order);
        }

        public class OrderService : IOrderService
        {
            public void Process(Order order)
            {
            }
        }

        #region Non-Mvvm
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var loggedIn = await LoginAsync(username, password);
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            return Task.FromResult(true);
        }

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtBillingAddress1;
        private TextBox txtBillingAddress2;
        private TextBox txtBillingCity;
        private TextBox txtBillingState;
        private TextBox txtBillingZip;
        private TextBox txtShippingAddress1;
        private TextBox txtShippingAddress2;
        private TextBox txtShippingCity;
        private TextBox txtShippingState;
        private TextBox txtShippingZip;
        private OrderService _orderService;

        public void ProcessOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                BillingAddress = new Address
                {
                    Address1 = txtBillingAddress1.Text,
                    Address2 = txtBillingAddress2.Text,
                    City = txtBillingCity.Text,
                    State = txtBillingState.Text,
                    Zip = txtBillingZip.Text
                },
                ShippingAddress = new Address
                {
                    Address1 = txtShippingAddress1.Text,
                    Address2 = txtShippingAddress2.Text,
                    City = txtShippingCity.Text,
                    State = txtShippingState.Text,
                    Zip = txtShippingZip.Text
                }
            };

            _orderService.Process(order);
        } 
        #endregion
    }
}
