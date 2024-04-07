using devdeer.AssetsManager.Logic.Common;
using devdeer.Libraries.Abstractions.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Models
{
    /// <summary>
    /// Represents a single asset in the backend application.
    /// </summary>
    public class AssetModel : BaseModel
    {
        #region properties

        /// <summary>
        /// Represents a unique assetkey of an asset.
        /// </summary>
        public string AssetKey { get; set; } = default!;
        /// <summary>
        /// Represents a unique serial number of an asset.
        /// </summary>
        public string SerialNumber { get; set; } = default!;
        /// <summary>
        /// Represents the condition state of an asset.
        /// </summary>
        public Condition State { get; set; } = default!;
        /// <summary>
        /// Represents the date when the asset was aquired.
        /// </summary>
        public DateOnly AcquisitionDate { get; set; } = default!;
        /// <summary>
        /// Represents the usage state of an asset.
        /// </summary>
        public UsageState Availability { get; set; } = default!;
        /// <summary>
        /// Represents the ownership state of an asset.
        /// </summary>
        public PropertyState Ownership { get; set; } = default!;
        /// <summary>
        /// Represents a comment for an asset.
        /// </summary>
        public string Comment { get; set; } = default!;
        /// <summary>
        /// Represents the name of the model of an asset.
        /// </summary>
        public string ModelName { get; set; } = default!;
        /// <summary>
        /// Represents the path to the picture of an asset.
        /// </summary>
        public string PrimaryImagePath { get; set; } = default!;
        /// <summary>
        /// Represents the path to the picture of the label of an asset.
        /// </summary>
        public string SecondaryImagePath { get; set; } = default!;

        #endregion
    }
}
