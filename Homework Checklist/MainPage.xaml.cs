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
        public MainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var btn = (ToolbarItem)sender;

            switch (btn.ClassId)
            {
                case "1":
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                    break;
                case "2":
                    Application.Current.MainPage = new NavigationPage(new AddHomeworkPage());
                    break;
                case "3":
                    Application.Current.MainPage = new LoginPage();
                    break;
            }
        }
    }
}
