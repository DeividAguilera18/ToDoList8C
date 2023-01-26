using System;
using System.Collections.Generic;
using System.Text;
using ToDoList8C.Models;
using ToDoList8C.Services.Interfaces;
using ToDoList8C.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoList8C.ViewModels
{
    class ItemListPageView : BaseViewModel
    {
        #region Properties
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private readonly IItemService _itemService;

        public ObservableCollection<IteemModel> Items { get; set; } = new ObservableCollection<IteemModel>();
        #endregion

        #region Constructor
        public ItemListPageView()
        {
            _itemService = DependencyService.Resolve<IItemService>();
            GetAllIten();
        }
        #endregion

        #region Methods
        private void GetAllIten()
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                var itemLIst = await _itemService.GetAllIten();

                Device.BeginInvokeOnMainThread(() =>
                {

                    Items.Clear();
                    if (itemLIst?.Count > 0)
                    {
                        foreach (var employee in itemLIst)
                        {
                            Items.Add(employee);
                        }
                    }
                    IsBusy = IsRefreshing = false;
                });

            });
        }
        #endregion

        #region Commands

        public ICommand RefreshCommand => new Command(() =>
        {
            IsRefreshing = true;
            GetAllIten();
        });

        public ICommand SelectedItemCommand => new Command<IteemModel>(async (item) =>
        {
            if (item != null)
            {
                var response = await App.Current.MainPage.DisplayActionSheet("Opciones!", "Cancelar", null, "Actualizar tarea", "Borrar tarea");

                if (response == "Actualizar tarea")
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddUpdateItem(item));
                }
                else if (response == "Borrar tarea")
                {
                    IsBusy = true;
                    bool deleteResponse = await _itemService.DeleteItem(item.Key);
                    if (deleteResponse)
                    {
                        GetAllIten();
                    }
                }
            }
        });
        #endregion

    }
}
