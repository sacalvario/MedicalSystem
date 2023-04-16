using System;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using MedicalSystem.Contracts.ViewModels;
using MedicalSystem.Core.Contracts.Services;
using MedicalSystem.Core.Models;

namespace MedicalSystem.ViewModels
{
    public class DataGridViewModel : ViewModelBase, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;

        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public DataGridViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await _sampleDataService.GetGridDataAsync();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
