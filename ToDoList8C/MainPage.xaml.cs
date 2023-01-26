using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ToDoList8C.Views;

namespace ToDoList8C
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void addItem_Clicked(object sender, EventArgs e) 
        {
            Navigation.PushAsync(new AddUpdateItem());
        }

        private void showItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemList());
        }

    }
}
