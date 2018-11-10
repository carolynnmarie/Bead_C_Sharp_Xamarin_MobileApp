using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeadCSharpMobileApp.Services{

    public interface IBeadRepo<T>{

        Task<bool> AddItemAsync(T bead);
        Task<bool> UpdateItemAsync(T bead);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
