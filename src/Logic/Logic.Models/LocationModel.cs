using devdeer.Libraries.Abstractions.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Models
{
    /// <summary>
    /// Represents a single location in the backend application.
    /// </summary>
    public class LocationModel : BaseModel
    {
        #region properties

        /// <summary>
        /// The label of the location.
        /// </summary>
        public string Label { get; set; } = default!;

        #endregion
    }
}
