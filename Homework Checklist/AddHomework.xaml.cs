using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homework_Checklist
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHomework : ContentPage
    {
        public AddHomework()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Send to server
        }
    }
}