using MauiApp2.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}