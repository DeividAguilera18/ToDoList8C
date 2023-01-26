using System;
using System.Collections.Generic;
using System.Text;
using ToDoList8C.Services.Interfaces;
using ToDoList8C.Services.Implementations;
using System.Windows.Input;
using Xamarin.Forms;
using ToDoList8C.Models;

namespace ToDoList8C.ViewModels
{
    public class AddUpdateItemPageViewModel : BaseViewModel
    {
        #region Properties
        private readonly IItemService _itemService;

        private IteemModel _Tododeteail = new IteemModel();

        public IteemModel Tododeteail
        {
            get => _Tododeteail;
            set => SetProperty(ref _Tododeteail, value);
        }
        #endregion

        #region Constructor
        public AddUpdateItemPageViewModel() 
        {
            _itemService = DependencyService.Resolve<IItemService>();
        }

        public AddUpdateItemPageViewModel(IteemModel ItemResponse) 
        {
            _itemService = DependencyService.Resolve<IItemService>();
            Tododeteail = new IteemModel
            {
                NombreTarea = ItemResponse.NombreTarea,
                Descripcion = ItemResponse.Descripcion,
                Estatus = ItemResponse.Estatus,
                Key = ItemResponse.Key
            };
        }

        #endregion

        #region Commands
        public ICommand SaveItemCommand => new Command(async () =>
        {
            if (IsBusy) return;
            IsBusy = true;
            bool res = await _itemService.AddOrUpdateItem(Tododeteail);
            if (res)
            {
                if (!string.IsNullOrWhiteSpace(Tododeteail.Key))
                {
                    await App.Current.MainPage.DisplayAlert("Exito!", "Tarea actualizada satisfactoriamente", "Ok");

                }
                else
                {
                    Tododeteail = new IteemModel() { };
                    await App.Current.MainPage.DisplayAlert("Exito!", "Tarea guardada satisfactoriamente", "Ok");
                }
            }
            IsBusy = false;
        });
        #endregion
    }
}
