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
    /// Default business logic for workplace.
    /// </summary>
    public class WorkplaceLogic : SimpleLogicBase<WorkplaceModel, long>, IWorkplaceLogic
    {

        #region constructors and destructors

        /// <inheritdoc />
        public WorkplaceLogic(IWorkplaceRepository repository) : base(repository)
        {
        }
        #endregion
    }
}
