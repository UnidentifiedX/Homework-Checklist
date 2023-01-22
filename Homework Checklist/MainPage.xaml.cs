using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Homework_Checklist
{
    public partial class MainPage : ContentPage
    {
        private GitHubClient _client;

        public MainPage(GitHubClient client)
        {
            InitializeComponent();

            _client = client;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var btn = (ToolbarItem)sender;

            switch (btn.ClassId)
            {
                case "1":
                    Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new MainPage(_client));
                    break;
                case "2":
                    Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new AddHomeworkPage(_client));
                    break;
                case "3":
                    Xamarin.Forms.Application.Current.MainPage = new LoginPage();
                    break;
            }
        }
    }
}
