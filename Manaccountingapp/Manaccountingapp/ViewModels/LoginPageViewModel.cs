using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manaccountingapp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
	    private string _email;
	    private string _password;
	    private string _apiUrl;

	    public string Email
	    {
	        get => _email;
	        set => SetProperty(ref _email, value);
	    }

	    public string Password
	    {
	        get => _password;
	        set => SetProperty(ref _password, value);
	    }

	    public string ApiUrl
	    {
	        get => _apiUrl;
	        set => SetProperty(ref _apiUrl, value);
	    }

        public DelegateCommand LoginButtonClickedCommand { get; }


        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ApiUrl = "http://localhost:3000/";
            LoginButtonClickedCommand = new DelegateCommand(LoginButtonClicked);
        }

	    private void LoginButtonClicked()
	    {
	        throw new NotImplementedException();
	    }
	}
}
