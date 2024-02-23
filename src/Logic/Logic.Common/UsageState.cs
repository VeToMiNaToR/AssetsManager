using System.ComponentModel.DataAnnotations;

namespace devdeer.AssetsManager.Logic.Common
{
    #region enums
    /// <summary>
    /// Represents a list of usage states for an asset.
    /// </summary>
    public enum UsageState
    {
        [Display(Name = "In Use")]
        InUse,
        [Display(Name = "Not Available")]
        NotAvailable,
        Available,
    }
    #endregion
}
