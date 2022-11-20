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
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        //private readonly ProductService _productService;
        public ProductPage()
        {
            InitializeComponent();      
        }

        private async void btn_product_save_Click(object sender, RoutedEventArgs e)
        {

            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:7130/api/products", new ProductCreateModel
            {
                Name = tb_product_name.Text,
                Description = tb_product_description.Text,
                Price = decimal.Parse(tb_product_price.Text)
            });
            tb_product_name.Text = string.Empty;
            tb_product_description.Text = string.Empty;
            tb_product_price.Text = string.Empty;
        }
    }
}
