using devdeer.Libraries.Abstractions.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Models
{
    /// <summary>
    /// Represents a single worker in the backend application.
    /// </summary>
    public class WorkerModel : BaseModel
    {
        #region properties

        /// <summary>
        /// The label of the worker.
        /// </summary>
        public string Label { get; set; } = default!;

        #endregion
    }
}
