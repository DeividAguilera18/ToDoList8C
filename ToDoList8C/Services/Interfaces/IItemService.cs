using System;
using System.Collections.Generic;
using System.Text;
using ToDoList8C.Models;
using System.Threading.Tasks;

namespace ToDoList8C.Services.Interfaces
{
    public interface IItemService
    {
        Task<bool> AddOrUpdateItem(IteemModel iteemModel);

        Task<bool> DeleteItem(string key);

        Task<List<IteemModel>> GetAllIten();
    }
}
