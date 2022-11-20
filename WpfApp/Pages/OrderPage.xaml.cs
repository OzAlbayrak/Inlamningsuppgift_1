using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Stripe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            PopulateProducts().ConfigureAwait(false);
            PopulateCustomers().ConfigureAwait(false);
        }
        public async Task PopulateProducts() 
        {
            var collection = new ObservableCollection<KeyValuePair<string, int>>();
            using var client = new HttpClient();

            foreach (var product in await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7130/api/products"))
                collection.Add(new KeyValuePair<string, int>(product.Name, product.Id));

            cb_product.ItemsSource = collection;
        }

        public async Task PopulateCustomers()
        {
            var collection = new ObservableCollection<KeyValuePair<string, int>>();
            using var client = new HttpClient();

            foreach (var customer in await client.GetFromJsonAsync<IEnumerable<CustomerModel>>("https://localhost:7130/api/customers"))
                collection.Add(new KeyValuePair<string, int>(customer.Name, customer.Id));

            cb_customer.ItemsSource = collection;
        }

        private async void btn_product_addToOrderList_Click(object sender, RoutedEventArgs e)
        {
            var customer = (KeyValuePair<string, int>)cb_customer.SelectedItem;
            var product = (KeyValuePair<string, int>)cb_product.SelectedItem;
            using var client = new HttpClient();
            lb_order_addedProductList.Items.Add("Produkt: \n" + product.Key + "\nAnatal:\n" + tb_product_ProductQuantitiy.Text + "\n");
       
            /*

            var orderRowCreate = new OrderRowCreateModel
            {
                ProductQuantitiy = int.Parse(tb_product_ProductQuantitiy.Text),
                ProductId = product.Value,
                ProductEntity = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7130/api/products")
            };
     

            */

            tb_product_ProductQuantitiy.Text = string.Empty;
            cb_product.SelectedIndex = -1;
        }

        private async void btn_order_save_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            var customer = (KeyValuePair<string, int>)cb_customer.SelectedItem;
            var product = (KeyValuePair<string, int>)cb_product.SelectedItem;

            await client.PostAsJsonAsync("https://localhost:7130/api/orders", new OrderCreateModel
            {
                OrderDate = DateTime.Now,
                OrderPrice = 499,
                CustomerId = customer.Value,
                CustomerName = customer.Key,
                CustomerEmail = "test@test.com",
                CustomerPhone = "test",
                CustomerStreetName = "test",
                CustomerCity = "test",
                CustomerPostalCode = "test",
                CustomerStreetNumber = 11,
                OrderRows = null
            });

            tb_product_ProductQuantitiy.Text = string.Empty;
            cb_product.SelectedIndex = -1;
            cb_customer.SelectedIndex = -1;
        }

    }
}






