using System.ComponentModel.DataAnnotations;

namespace devdeer.AssetsManager.Logic.Common
{
    #region enums
    /// <summary>
    /// Represents a list of usage states for an asset.
    /// </summary>
    public enum UsageState
    {
        Undefined = 0,
        InUse = 1,
        NotAvailable = 2,
        Available = 3
    }
    #endregion
}
