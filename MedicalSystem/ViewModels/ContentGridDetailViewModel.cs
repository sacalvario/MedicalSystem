using System;
using System.Linq;

using GalaSoft.MvvmLight;

using MedicalSystem.Contracts.ViewModels;
using MedicalSystem.Core.Contracts.Services;
using MedicalSystem.Core.Models;

namespace MedicalSystem.ViewModels
{
    public class ContentGridDetailViewModel : ViewModelBase, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public ContentGridDetailViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is long orderID)
            {
                var data = await _sampleDataService.GetContentGridDataAsync();
                Item = data.First(i => i.OrderID == orderID);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
