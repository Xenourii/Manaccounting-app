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
            _restService = restService;
            ApiUrl = "http://localhost:3000/";
            LoginButtonClickedCommand = new DelegateCommand(LoginButtonClicked);
        }

	    private async void LoginButtonClicked()
	    {
	        var url = ApiUrl + "user/login";
	        var loginInfo = new LoginInfo {Email = Email, Password = Password};
	        var loginReponse = await _restService.LoginUserAsync(url, loginInfo);
	        UserSessionToken = loginReponse.Token;
	    }
	}
}
