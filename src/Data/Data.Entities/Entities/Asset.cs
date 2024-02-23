using Azure.Core;
using devdeer.Libraries.Abstractions.BaseTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Common.Enums;

namespace devdeer.AssetsManager.Data.Entities.Entities
{
    /// <summary>
    /// Represents an asset in the datastore.
    /// </summary>
    [Table(nameof(Asset), Schema = "AssetData")]
    public class Asset : BaseEntity
    {
        #region properties
        /// <summary>
        /// Represents the foreign key to brand entity.
        /// </summary>
        [Required]
        public long BrandId { get; set; } = default!;

        /// <summary>
        /// Represents the gateway to access the properties of the brand entity.
        /// </summary>
        public virtual Brand Brand { get; set; } = default!; 

        /// <summary>
        /// Represents the foreign key to category entity.
        /// </summary>
        public long CategoryId { get; set; } = default!;

        /// <summary>
        /// Represents the gateway to access the properties of the category entity.
        /// </summary>
        public virtual Category Category { get; set; } = default!;

        /// <summary>
        /// Represents the foreign key to location entity.
        /// </summary>
        public long LocationId { get; set; } = default!;

        /// <summary>
        /// Represents the gateway to access the properties of the location entity.
        /// </summary>
        public virtual Location Location { get; set; } = default!; 

        /// <summary>
        /// Represents the foreign key to workplace entity.
        /// </summary>
        public long WorkplaceId { get; set; } = default!;

        /// <summary>
        /// Represents the gateway to access the properties of the workplace entity.
        /// </summary>
        public virtual Workplace Workplace { get; set; } = default!; 

        /// <summary>
        /// Represents the foreign key to worker entity.
        /// </summary>
        public long WorkerId { get; set; } = default!;

        /// <summary>
        /// Represents the gateway to access the properties of the worker entity.
        /// </summary>
        public virtual Worker Worker { get; set; } = default!; 

        /// <summary>
        /// Represents a unique assetkey of an asset.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string AssetKey { get; set; } = default!;

        /// <summary>
        /// Represents a unique serial number of an asset.
        /// </summary>
        [Required]
        [StringLength(50)]
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
        [Required]
        public UsageState Availability { get; set; } = default!;

        /// <summary>
        /// Represents the ownership state of an asset.
        /// </summary>
        [Required]
        public PropertyState Ownership { get; set; } = default!;

        /// <summary>
        /// Represents a comment for an asset.
        /// </summary>
        [StringLength(500)]
        public string Comment { get; set; } = default!;

        /// <summary>
        /// Represents the name of the model of an asset.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ModelName { get; set; } = default!;

        /// <summary>
        /// Represents the path to the picture of an asset.
        /// </summary>
        [StringLength(500)]
        public string PrimaryImagePath { get; set; } = default!;

        /// <summary>
        /// Represents the path to the picture of the label of an asset.
        /// </summary>
        [StringLength(500)]
        public string SecondaryImagePath { get; set; } = default!;
        #endregion
    }
}
