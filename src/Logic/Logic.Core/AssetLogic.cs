namespace devdeer.AssetsManager.Logic.Core
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Interfaces.Logic;
    using Interfaces.Repositories;

    using Libraries.Abstractions.BaseTypes;

    using Models;

    /// <summary>
    /// Default business logic for asset.
    /// </summary>
    public class AssetLogic : SimpleLogicBase<AssetModel, long>, IAssetLogic
    {
        #region constructors and destructors

        /// <inheritdoc />
        public AssetLogic(IAssetRepository repository) : base(repository)
        {
        }

        #endregion

        #region explicit interfaces

        /// <inheritdoc />
        public async ValueTask<bool> GetKeyExistsAsync(string key)
        {
            return await SpecificRepository.GetKeyExistsAsync(key);
        }

        #endregion

        #region properties

        /// <summary>
        /// The inherited repository cast to the specific interface type.
        /// </summary>
        private IAssetRepository SpecificRepository => (IAssetRepository)Repository;

        #endregion
    }
}