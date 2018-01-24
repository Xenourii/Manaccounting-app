using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Manaccountingapp.Models;
using Manaccountingapp.Services;
using Xamarin.Forms;

namespace Manaccountingapp.ViewModels
{
	public class ProductPageViewModel : ViewModelBase
	{
	    private readonly IRestService _restService;
	    private Product _product;
	    private string _price;
	    private string _name;
	    private string _description;
	    private string _category;
	    private string _brand;
	    private string _memory;
	    private string _refreshRate;
	    private string _batteryLife;
	    private string _os;
	    private string _interface;
	    private string _guarantee;
	    private string _contactMail;
	    private string _returnAddress;
	    private int _numberToOrder = 0;
	    private bool _isOrderButtonEnabled = true;

	    public Product Product
	    {
	        get => _product;
	        set => SetProperty(ref _product, value);
	    }

	    public int NumberToOrder
	    {
	        get { return _numberToOrder; }
	        set
	        {
                if(_numberToOrder.Equals(value))
                    return;
	            _numberToOrder = value;
	            if (_numberToOrder < 0) _numberToOrder = 0;
                RaisePropertyChanged();
	            IsOrderButtonEnabled = NumberToOrder > 0;
	        }
	    }

	    public bool IsOrderButtonEnabled
	    {
	        get => _isOrderButtonEnabled;
	        set => SetProperty(ref _isOrderButtonEnabled, value);
	    }

	    public string Name
	    {
	        get => _name;
	        set => SetProperty(ref _name, value);
	    }

	    public string Price
	    {
	        get => _price;
	        set => SetProperty(ref _price, value);
	    }

	    public string Description
	    {
	        get => _description;
	        set => SetProperty(ref _description, value);
	    }

	    public string Category
	    {
	        get => _category;
	        set => SetProperty(ref _category, value);
	    }

	    public string Brand
	    {
	        get => _brand;
	        set => SetProperty(ref _brand, value);
	    }

	    public string Memory
	    {
	        get => _memory;
	        set => SetProperty(ref _memory, value);
	    }

	    public string Refresh_Rate
	    {
	        get => _refreshRate;
	        set => SetProperty(ref _refreshRate, value);
	    }

	    public string Battery_Life
	    {
	        get => _batteryLife;
	        set => SetProperty(ref _batteryLife, value);
	    }

	    public string Os
	    {
	        get => _os;
	        set => SetProperty(ref _os, value);
	    }

	    public string Interface
	    {
	        get => _interface;
	        set => SetProperty(ref _interface, value);
	    }

	    public string Guarantee
	    {
	        get => _guarantee;
	        set => SetProperty(ref _guarantee, value);
	    }

	    public string Contact_Mail
	    {
	        get => _contactMail;
	        set => SetProperty(ref _contactMail, value);
	    }

	    public string Return_Address
	    {
	        get => _returnAddress;
	        set => SetProperty(ref _returnAddress, value);
	    }

        public DelegateCommand OnOrderButtonClickedCommand { get; }

        public ProductPageViewModel(INavigationService navigationService, IRestService restService) : base(navigationService)
        {
            _restService = restService;
            OnOrderButtonClickedCommand = new DelegateCommand(OnOrderButtonClicked);
        }

	    private async void OnOrderButtonClicked()
	    {
            var orderInfo = new OrderInfo{ProductId = Product.Id, ProductNumber = NumberToOrder};
	        var orderResponse = await _restService.OrderPostAsync(UserApiUrl + "api/order", orderInfo, UserSessionToken);
	        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            Device.OpenUri(new Uri(UserApiUrl + "Public/invoice_" + orderResponse.OrderId + ".pdf"));
	    }

	    public override void OnNavigatingTo(NavigationParameters parameters)
	    {
            base.OnNavigatingTo(parameters);
	        if (parameters.ContainsKey("product"))
	            Product = (Product) parameters["product"];

	        Name = Product.Name;
	        Price = "Price: €" + Product.Price;
	        Description = "Description: " + Product.Description;
	        Category = "Category " + Product.Category;
	        Brand = "Brand: " + Product.Brand;
	        Memory = "Memory: " + Product.Memory;
	        Refresh_Rate = "Refresh rate: " + Product.Refresh_Rate;
	        Battery_Life = "Battery life: " +  Product.Battery_Life;
	        Os = "Operating system: " + Product.Os;
	        Interface = "Interface: " + Product.Interface;
	        Guarantee = "Guarantee: " + Product.Guarantee + " year(s)";
	        Contact_Mail = "Contact Email: " + Product.Contact_Mail;
	        Return_Address = "Return address: " + Product.Return_Address;
	    }
    }
}
