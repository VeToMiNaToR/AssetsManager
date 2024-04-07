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
    /// Default business logic for location.
    /// </summary>
    public class LocationLogic : SimpleLogicBase<LocationModel, long>, ILocationLogic
    {
        #region constructors and destructors

        /// <inheritdoc />
        public LocationLogic(ILocationRepository repository) : base(repository)
        {
        }

        #endregion
    }
}
