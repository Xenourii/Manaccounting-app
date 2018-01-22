using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Manaccountingapp.Models;
using Manaccountingapp.Services;

namespace Manaccountingapp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
	    private readonly INavigationService _navigationService;
	    private readonly IRestService _restService;
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


        public LoginPageViewModel(INavigationService navigationService, IRestService restService) : base(navigationService)
        {
            _navigationService = navigationService;
            _restService = restService;
            ApiUrl = "http://192.168.1.17:3000/";
            LoginButtonClickedCommand = new DelegateCommand(LoginButtonClicked);
        }

	    private async void LoginButtonClicked()
	    {
	        UserApiUrl = ApiUrl;
            var url = UserApiUrl + "api/user/login";
            var loginInfo = new LoginInfo { Email = Email, Password = Password };
            var loginReponse = await _restService.LoginUserPostAsync(url, loginInfo);
            UserSessionToken = loginReponse.Token;

	        await _navigationService.NavigateAsync("ProductsPage");
	    }
	}
}
