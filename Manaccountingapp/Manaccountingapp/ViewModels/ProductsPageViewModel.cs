using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Manaccountingapp.Models;
using Manaccountingapp.Services;
using Prism.Navigation;

namespace Manaccountingapp.ViewModels
{
	public class ProductsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRestService _restService;
        private List<Product> _products;
        private bool _refreshButtonEnabled = true;

        public List<Product> Products
	    {
	        get => _products;
	        set => SetProperty(ref _products, value);
	    }

        public bool RefreshButtonEnabled
        {
            get { return _refreshButtonEnabled; }
            set { SetProperty(ref _refreshButtonEnabled, value); }
        }

        public DelegateCommand RefreshButtonClickedCommand { get; }
        public DelegateCommand<object> ItemTappedCommand { get; }

        public ProductsPageViewModel(INavigationService navigationService, IRestService restService) : base(navigationService)
	    {
	        _navigationService = navigationService;
	        _restService = restService;

        RefreshButtonClickedCommand = new DelegateCommand(RefreshButtonClicked);
	    ItemTappedCommand = new DelegateCommand<object>(ItemTapped);
    }

        private async void ItemTapped(object obj)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("product", obj);
            await _navigationService.NavigateAsync("ProductPage", navigationParams);
        }

        private async void RefreshButtonClicked()
        {
            Products = await _restService.GetProductsDataAsync(UserApiUrl + "api/products", UserSessionToken);
            RefreshButtonEnabled = false;
        }
    }
}
