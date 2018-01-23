using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Manaccountingapp.Models;

namespace Manaccountingapp.ViewModels
{
	public class ProductPageViewModel : ViewModelBase
	{
	    private Product _product;

	    public Product Product
	    {
	        get => _product;
	        set => SetProperty(ref _product, value);
	    }

	    public ProductPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

	    public override void OnNavigatingTo(NavigationParameters parameters)
	    {
            base.OnNavigatingTo(parameters);
	        if (parameters.ContainsKey("product"))
	            Product = (Product) parameters["product"];
	    }
    }
}
