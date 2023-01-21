using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                username.Text = Application.Current.Properties["Username"].ToString();
                auth.Text = Application.Current.Properties["Auth"].ToString();
            }
            catch { }
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (rememberMeCheckbox.IsChecked)
            {
                Application.Current.Properties["Username"] = username.Text;
                Application.Current.Properties["Auth"] = auth.Text;
                await Application.Current.SavePropertiesAsync();
            }

            //Placeholder Authenticator
            if (auth.Text == "kokhongsocute" && username.Text == "Kok")
            {
                Debug.WriteLine("Kok Hong <3");
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Login Failed", "User: Kok\nAuth: kokhongsocute", "OK");
            }
        }

        //hides/shows auth field
        private void isPassword_Clicked(object sender, EventArgs e)
        {
            auth.IsPassword = !auth.IsPassword;
        }
    }
}