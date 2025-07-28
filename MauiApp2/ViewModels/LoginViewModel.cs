using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp2.Services;
using System;
using System.Threading.Tasks;

namespace MauiApp2.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        // Constructor for dependency injection
        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
        }

        // Parameterless constructor for design-time support
        public LoginViewModel() : this(new AuthService())
        {
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                ErrorMessage = "Please enter your username";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter your password";
                return;
            }

            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                // Call the authentication service
                var response = await _authService.LoginAsync(Username, Password);

                if (response.Success)
                {
                    // In a real app, you would store the token for future API calls
                    // For example: SecureStorage.SetAsync("auth_token", response.Token);

                    // Navigate to main page on successful login
                    await Shell.Current.GoToAsync("//MainPage");
                }
                else
                {
                    ErrorMessage = response.ErrorMessage ?? "Authentication failed";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Login failed: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}