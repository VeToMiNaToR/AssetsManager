using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Common
{
    #region enums
    /// <summary>
    /// Represents a list of property states for an asset.
    /// </summary>
    public enum PropertyState 
    {
        Undefined = 0,
        Leased = 1,
        Rented = 2,
        Property = 3
    }
    #endregion
}
