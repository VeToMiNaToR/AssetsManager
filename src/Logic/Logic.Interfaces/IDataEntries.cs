using devdeer.AssetsManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Interfaces
{
    public interface IDataEntries
    {
        Task<DataEntries> CreateAsync(DataEntries entries);

        Task<bool> DeleteAsync(string InventoryCode);

        Task<DataEntries[]> GetAsync();

        Task<DataEntries?> GetAsync(string InventoryCode);

        Task<DataEntries> UpdateAsync(DataEntries entries);

        Task<int> GetCountAsync();
    }
}
