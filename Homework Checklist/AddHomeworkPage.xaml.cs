using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Octokit;
using System.Net.Http;

using System.Text.Json;
using System.Diagnostics;
using Xamarin.Essentials;
using Homework_Checklist.Models;

namespace Homework_Checklist
{

    public partial class AddHomeworkPage : ContentPage
    {
        private GitHubClient _client;
        
        public AddHomeworkPage(GitHubClient client)
        {
            InitializeComponent();

            _client = client;
        }

        private async void AddHomeworkButton_Clicked(object sender, EventArgs e)
        {
            //Create Json data file
            var homework = new Homework
            {
                Title = title.Text,
                Date = date.Date,
                Description = description.Text
            };

            await UpdateHomework(homework);

            //string jsonString = JsonSerializer.Serialize(homework);

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
        
        public async Task UpdateHomework(Homework homework)
        {
            var currentHomework = (await _client.Repository.Content.GetAllContents("OSdoge", "Homework-Checklist-Server", "work.json")).First().Content;
            var homeworkList = JsonSerializer.Deserialize<List<Homework>>(currentHomework);

            homeworkList.Add(homework);

            var homeworkString = JsonSerializer.Serialize(homeworkList);

            var updateRequest = new UpdateFileRequest($"Added homework for {DateTime.Now:dd/MM/yyyy}", homeworkString, currentHomework);

            await _client.Repository.Content.CreateFile("OSdoge", "Homework-Checklist-Server", "work.json", updateRequest);
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