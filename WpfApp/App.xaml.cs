﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Contexts;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IHost? app { get; private set; }

        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddScoped<MainWindow>();
                services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\oz\\source\\repos\\CMS22\\cms22-csharp\\Inlamningsuppgift_1\\Inlamningsuppgift_1\\Contexts\\local_sql_db_WebApi.mdf;Integrated Security=True;Connect Timeout=30"));
                services.AddScoped<CustomerService>();
                services.AddScoped<ProductService>();
            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await app!.StartAsync();
            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

    }
}
