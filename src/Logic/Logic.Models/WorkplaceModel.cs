using devdeer.Libraries.Abstractions.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Models
{
    /// <summary>
    /// Represents a single workplace in the backend application.
    /// </summary>
    public class WorkplaceModel : BaseModel
    {

        #region properties

        /// <summary>
        /// The label of the workplace.
        /// </summary>
        public string Label { get; set; } = default!;

        #endregion
    }
}
