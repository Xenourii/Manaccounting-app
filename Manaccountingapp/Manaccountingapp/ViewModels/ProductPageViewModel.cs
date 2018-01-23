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

	    public Product Product
	    {
	        get => _product;
	        set => SetProperty(ref _product, value);
	    }

	    public string Name
	    {
	        get { return _name; }
	        set { SetProperty(ref _name, value); }
	    }

	    public string Price
	    {
	        get { return _price; }
	        set { SetProperty(ref _price, value); }
	    }

	    public string Description
	    {
	        get { return _description; }
	        set { SetProperty(ref _description, value); }
	    }

	    public string Category
	    {
	        get { return _category; }
	        set { SetProperty(ref _category, value); }
	    }

	    public string Brand
	    {
	        get { return _brand; }
	        set { SetProperty(ref _brand, value); }
	    }

	    public string Memory
	    {
	        get { return _memory; }
	        set { SetProperty(ref _memory, value); }
	    }

	    public string Refresh_Rate
	    {
	        get { return _refreshRate; }
	        set { SetProperty(ref _refreshRate, value); }
	    }

	    public string Battery_Life
	    {
	        get { return _batteryLife; }
	        set { SetProperty(ref _batteryLife, value); }
	    }

	    public string Os
	    {
	        get { return _os; }
	        set { SetProperty(ref _os, value); }
	    }

	    public string Interface
	    {
	        get { return _interface; }
	        set { SetProperty(ref _interface, value); }
	    }

	    public string Guarantee
	    {
	        get { return _guarantee; }
	        set { SetProperty(ref _guarantee, value); }
	    }

	    public string Contact_Mail
	    {
	        get { return _contactMail; }
	        set { SetProperty(ref _contactMail, value); }
	    }

	    public string Return_Address
	    {
	        get { return _returnAddress; }
	        set { SetProperty(ref _returnAddress, value); }
	    }


	    public ProductPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

	    public override void OnNavigatingTo(NavigationParameters parameters)
	    {
            base.OnNavigatingTo(parameters);
	        if (parameters.ContainsKey("product"))
	            Product = (Product) parameters["product"];

	        Name = Product.Name;
	        Price = Product.Price + " €";
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
