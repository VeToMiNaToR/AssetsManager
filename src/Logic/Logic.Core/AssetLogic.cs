using devdeer.AssetsManager.Logic.Interfaces.Logic;
using devdeer.AssetsManager.Logic.Interfaces.Repositories;
using devdeer.AssetsManager.Logic.Models;
using devdeer.Libraries.Abstractions.BaseTypes;
using devdeer.Libraries.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Core
{
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
    }
}
