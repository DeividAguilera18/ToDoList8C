using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoList8C.ViewModels;
using ToDoList8C.Models;

namespace ToDoList8C.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUpdateItem : ContentPage
    {
        public AddUpdateItem()
        {
            InitializeComponent();
            this.BindingContext = new AddUpdateItemPageViewModel();
        }

        public AddUpdateItem(IteemModel iteemModel) 
        {
            InitializeComponent();
            this.BindingContext = new AddUpdateItemPageViewModel(iteemModel);
        }
    }
}