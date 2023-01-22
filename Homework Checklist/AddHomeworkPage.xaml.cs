using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Octokit;
using System.Net.Http;

using System.Text.Json;
using System.Diagnostics;
using Xamarin.Essentials;

namespace Homework_Checklist
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    //JSON
    public class NewHomework
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }

    public partial class AddHomeworkPage : ContentPage
    {
        private GitHubClient _client;
        
        public AddHomeworkPage(GitHubClient client)
        {
            InitializeComponent();

            _client = client;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Create Json data file
            var newHomework = new NewHomework
            {
                Title = title.Text,
                Date = date.Date,
                Description = description.Text
            };

            string jsonString = JsonSerializer.Serialize(newHomework);

            //Send to server
            //await CreateFile(jsonString);

            //Get from server
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
                    try
                    {
                        SecureStorage.RemoveAll();
                    }
                    catch { }
                    
                    Xamarin.Forms.Application.Current.MainPage = new LoginPage();
                    break;
            }
        }

        //public async Task CreateFile(string data, string owner = "OSdoge", string repoName = "Homework-Checklist-Server", string filePath = "data.json", string message = "N/A", string branch = "main")
        //{
        //    var token = Xamarin.Forms.Application.Current.Properties["Auth"].ToString();
        //    var userAgent = Xamarin.Forms.Application.Current.Properties["Username"].ToString();


        //    var tokenAuth = new Credentials(token);
        //    var client = new GitHubClient(new ProductHeaderValue(userAgent));
        //    string url = $"https://api.github.com/repos/{owner}/{repoName}/contents/{filePath}";

        //    //Authentication
        //    client.Credentials = tokenAuth;

        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);

        //    var request = new CreateFileRequest(message, data);
        //    var result = (await client.Repository.Content.CreateFile(owner, repoName, filePath, request)).Content;
        //    Debug.WriteLine(result);
        //}

    }
}