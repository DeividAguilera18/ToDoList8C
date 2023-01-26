using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using ToDoList8C.Models;
using ToDoList8C.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList8C.Services.Implementations
{
    public class ItemService : IItemService
    {
        FirebaseClient firebase = new FirebaseClient(Setting.FireBaseDatabaseUrl, new FirebaseOptions
        {
            AuthTokenAsyncFactory =() => Task.FromResult(Setting.FireBaseSeceret)
        });

            public async Task<bool> AddOrUpdateItem(IteemModel iteemModel) 
            {
                if (!string.IsNullOrWhiteSpace(iteemModel.Key))
                {
                    try
                    {
                    await firebase.Child(nameof(IteemModel)).Child(iteemModel.Key).PutAsync(iteemModel);
                    return true;
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                }
                else 
                {
                    var response = await firebase.Child(nameof(IteemModel)).PostAsync(iteemModel);
                    if (response.Key != null)
                    {
                        return true;
                    } 
                    else 
                    {
                    return false;
                    }
                    
                }
            }

            
            public async Task<bool> DeleteItem(string key) 
            { 
            
                try 
                {
                    await firebase.Child(nameof(IteemModel)).Child(key).DeleteAsync();
                    return true;
                }
                catch (Exception ex) 
                {
                return false;
                }
        
            }


            public async Task<List<IteemModel>> GetAllIten() 
            { 
                return (await firebase.Child(nameof(IteemModel)).OnceAsync<IteemModel>()).Select(f => new IteemModel
                {
                    NombreTarea = f.Object.NombreTarea,
                    Descripcion = f.Object.Descripcion,
                    Estatus = f.Object.Estatus,
                    Key = f.Key
                    
                }).ToList();
            }



    }
}
