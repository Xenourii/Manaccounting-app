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
        private readonly IRestService _restService;
        private List<Product> _products;

	    public List<Product> Products
	    {
	        get { return _products; }
	        set { SetProperty(ref _products, value); }
	    }

        public DelegateCommand RefreshButtonClickedCommand { get; }

        public ProductsPageViewModel(INavigationService navigationService, IRestService restService) : base(navigationService)
	    {
	        _restService = restService;

        RefreshButtonClickedCommand = new DelegateCommand(RefreshButtonClicked);
    }

        private async void RefreshButtonClicked()
        {
            Products = await _restService.GetProductsDataAsync(UserApiUrl + "api/products", UserSessionToken); //Not sure about the *.Result thing TODO Check that
        }
    }
}
