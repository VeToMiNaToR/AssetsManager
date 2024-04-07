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
    /// Default business logic for worker.
    /// </summary>
    public class WorkerLogic : SimpleLogicBase<WorkerModel, long>, IWorkerLogic
    {
        #region constructors and destructors

        /// <inheritdoc />
        public WorkerLogic(IWorkerRepository repository) : base(repository)
        {
        }
        #endregion
    }
}
