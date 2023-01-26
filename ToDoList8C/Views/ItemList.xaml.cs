using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList8C.Models;
using ToDoList8C.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList8C.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemList : ContentPage
    {
        public ItemList()
        {
            InitializeComponent();
            this.BindingContext = new ItemListPageView();
        }
    }
}