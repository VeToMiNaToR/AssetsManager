namespace devdeer.AssetsManager.Logic.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Libraries.Abstractions.Interfaces;

    using Models;

    /// <summary>
    /// Must be implemented by repositories dealing with asset data.
    /// </summary>
    public interface IAssetRepository : ISimpleRepository<AssetModel, long>
    {
        #region methods

        /// <summary>
        /// Checks if a given <paramref name="key" /> is already taken.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the key is taken otherwise <c>false</c>.</returns>
        ValueTask<bool> GetKeyExistsAsync(string key);

        #endregion
    }
}