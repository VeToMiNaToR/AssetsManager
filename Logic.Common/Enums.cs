using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Common
{
    /// <summary>
    /// Represents a collection of lists which provide the properties with options to select from.
    /// </summary>
    public class Enums
    {
        #region enums

        /// <summary>
        /// Represents a list of condition states for an asset.
        /// </summary>
        public enum Condition
        {
            Functional,
            Malfunctional,
            Inoperable,
            RMA,
        }
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
        /// <summary>
        /// Represents a list of property states for an asset.
        /// </summary>
        public enum PropertyState 
        {
            Leased,
            Rented,
            Property,
        }
        #endregion
    }
}
