using System;
using Xamarin.Forms.Xaml;

namespace Homework_Checklist.Models
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    //JSON
    public class Homework
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}