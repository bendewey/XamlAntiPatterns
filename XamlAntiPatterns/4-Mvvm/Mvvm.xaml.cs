using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
        }

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

        public class OrderService
        {
            public void Process(Order order)
            {
            }
        }
    }
}
