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
	public class ProductsPageViewModel : ViewModelBase, INavigationAware
    {
        private readonly IRestService _restService;
        private List<Product> _products;

	    public List<Product> Products
	    {
	        get { return _products; }
	        set { SetProperty(ref _products, value); }
	    }

	    public ProductsPageViewModel(INavigationService navigationService, IRestService restService) : base(navigationService)
	    {
	        _restService = restService;
	    }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            Products = _restService.GetProductsDataAsync(UserApiUrl).Result; //Not sure about the *.Result thing TODO Check that
        }
    }
}
