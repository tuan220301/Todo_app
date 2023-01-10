using System;
using Todo_app.Database;
using Todo_app.Models;
using Todo_app.Services;
using Todo_app.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo_app
{
    public partial class App : Application
    {
        public static NoteController NoteController = new NoteController();
        public static UserController UserController= new UserController();
        public App()
        {
            InitializeComponent();

            /*DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();*/
            /*var isEmpty = (App.UserController.ReadUser()).ToArray();
            Console.WriteLine("Length of list user" + isEmpty.Length);
            if (isEmpty.Length == 0)
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainPage = new AppShell();
            }*/
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
