using devdeer.AssetsManager.Data.Entities;
using devdeer.AssetsManager.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Interfaces
{
    public interface IAsset
    {
        Task<Asset> CreateAsync(Asset entries);

        Task<bool> DeleteAsync(string InventoryCode);

        Task<Asset[]> GetAsync();

        Task<Asset?> GetAsync(string InventoryCode);

        Task<Asset> UpdateAsync(Asset entries);

        Task<int> GetCountAsync();
    }
}
