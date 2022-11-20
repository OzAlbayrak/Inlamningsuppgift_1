using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        public CustomerPage()
        {
            InitializeComponent();
        }


        private async void btn_cusomer_save_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();

            await client.PostAsJsonAsync("https://localhost:7130/api/customers", new CustomerCreateModel
            {
                Name = tb_customer_name.Text,
                Email = tb_customer_email.Text,
                Phone = tb_customer_phone.Text,
                StreetName = tb_customer_StreetName.Text,
                City = tb_customer_city.Text,
                PostalCode = tb_customer_PostalCode.Text,
                StreetNumber = int.Parse(tb_customer_StreetNumber.Text)
            });
            

            tb_customer_name.Text = string.Empty;
            tb_customer_email.Text = string.Empty;
            tb_customer_phone.Text = string.Empty;
            tb_customer_StreetName.Text = string.Empty;
            tb_customer_city.Text = string.Empty;
            tb_customer_PostalCode.Text = string.Empty;
            tb_customer_StreetNumber.Text = string.Empty;
        }

    }
}
