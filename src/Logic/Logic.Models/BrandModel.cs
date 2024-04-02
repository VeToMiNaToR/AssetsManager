namespace devdeer.AssetsManager.Logic.Models
{
    using System;
    using System.Linq;

    using Libraries.Abstractions.BaseTypes;

    /// <summary>
    /// Represents a single brand in the backend application.
    /// </summary>
    public class BrandModel : BaseModel
    {
        #region properties

        /// <summary>
        /// The label of the brand.
        /// </summary>
        public string Label { get; set; } = default!;

        #endregion
    }
}