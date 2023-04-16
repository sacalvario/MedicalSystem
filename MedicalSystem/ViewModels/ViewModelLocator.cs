using System;
using System.Windows.Controls;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

using MedicalSystem.Contracts.Services;
using MedicalSystem.Contracts.Views;
using MedicalSystem.Core.Contracts.Services;
using MedicalSystem.Core.Services;
using MedicalSystem.Models;
using MedicalSystem.Services;
using MedicalSystem.Views;

using Microsoft.Extensions.Configuration;

namespace MedicalSystem.ViewModels
{
    public class ViewModelLocator
    {
        private IPageService PageService
            => SimpleIoc.Default.GetInstance<IPageService>();

        public ShellViewModel ShellViewModel
            => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public MainViewModel MainViewModel
            => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ListDetailsViewModel ListDetailsViewModel
            => SimpleIoc.Default.GetInstance<ListDetailsViewModel>();

        public ContentGridViewModel ContentGridViewModel
            => SimpleIoc.Default.GetInstance<ContentGridViewModel>();

        public ContentGridDetailViewModel ContentGridDetailViewModel
            => SimpleIoc.Default.GetInstance<ContentGridDetailViewModel>();

        public DataGridViewModel DataGridViewModel
            => SimpleIoc.Default.GetInstance<DataGridViewModel>();

        public ViewModelLocator()
        {
            // App Host
            SimpleIoc.Default.Register<IApplicationHostService, ApplicationHostService>();

            // Activation Handlers

            // Core Services
            SimpleIoc.Default.Register<ISampleDataService, SampleDataService>();

            // Services
            SimpleIoc.Default.Register<IPageService, PageService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            // Window
            SimpleIoc.Default.Register<IShellWindow, ShellWindow>();
            SimpleIoc.Default.Register<ShellViewModel>();

            // Pages
            Register<MainViewModel, MainPage>();
            Register<ListDetailsViewModel, ListDetailsPage>();
            Register<ContentGridViewModel, ContentGridPage>();
            Register<ContentGridDetailViewModel, ContentGridDetailPage>();
            Register<DataGridViewModel, DataGridPage>();
        }

        private void Register<VM, V>()
            where VM : ViewModelBase
            where V : Page
        {
            SimpleIoc.Default.Register<VM>();
            SimpleIoc.Default.Register<V>();
            PageService.Configure<VM, V>();
        }

        public void AddConfiguration(IConfiguration configuration)
        {
            var appConfig = configuration
                .GetSection(nameof(AppConfig))
                .Get<AppConfig>();

            // Register configurations to IoC
            SimpleIoc.Default.Register(() => configuration);
            SimpleIoc.Default.Register(() => appConfig);
        }
    }
}
