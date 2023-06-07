using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using TestGenerator.Core;
using TestGenerator.MVVM.ViewModel;
using TestGenerator.MVVM.Views;
using TestGenerator.Services;

namespace TestGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindowView>(provider => new MainWindowView
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<GenerateViewModel>();
            services.AddSingleton<QuestionViewModel>();
            services.AddSingleton<INavigationService, Services.NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider =>
            {
                return viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType);
            });


            //services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService<viewModelType>);

            _serviceProvider = services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow=_serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
