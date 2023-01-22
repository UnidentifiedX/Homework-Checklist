using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homework_Checklist
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            LoadSavedData();
        }

        private async void LoadSavedData()
        {
            try
            {
                var username = await SecureStorage.GetAsync("username");
                var password = await SecureStorage.GetAsync("password");
                
                if (username != null && password != null)
                {
                    Login(username, password);
                }
            }
            catch
            {

            }
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var username = usernameEntry.Text;
            var password = passwordEntry.Text;
            
            Login(username, password);
        }

        private async void Login(string username, string password)
        {
            var client = new GitHubClient(new ProductHeaderValue(username));
            var basicAuth = new Credentials(username, password);

            client.Credentials = basicAuth;

            try
            {
                var _ = await client.Repository.Get("OSdoge", "Homework-Checklist-Server");


                if (rememberMeCheckbox.IsChecked)
                {
                    try
                    {
                        await SecureStorage.SetAsync("username", username);
                        await SecureStorage.SetAsync("password", password);
                    }
                    catch
                    {

                    }
                }

                Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new MainPage(client));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login Failed", "The username or password is incorrect.", "OK");
            }
        }

        //hides/shows auth field
        private void ShowPassword_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            
            passwordEntry.IsPassword = !passwordEntry.IsPassword;
            
            button.Source = passwordEntry.IsPassword ? "ic_action_visibility_on.png" : "ic_action_visibility_off.png";
        }
    }
}