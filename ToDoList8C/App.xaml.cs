using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoList8C.Services.Implementations;
using ToDoList8C.Services.Interfaces;

namespace ToDoList8C
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            DependencyService.Register<IItemService, ItemService>();
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
