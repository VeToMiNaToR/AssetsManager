using Azure.Core;
using devdeer.AssetsManager.Data.Entities.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Data.Entities.Entities
{
    /// <summary>
    /// Represents an asset in the datastore.
    /// </summary>
    [Table(nameof(Asset), Schema = "BaseData")]
    public class Asset : BaseEntity
    {
        #region properties
        /// <summary>
        /// Represents the foreign key to brand entity.
        /// </summary>
        [Required]
        public long BrandId { get; set; } = default!;

        public virtual Brand Brand { get; set; } = default!; 

        /// <summary>
        /// Represents the foreign key to category entity.
        /// </summary>
        public long CategoryId { get; set; } = default!;

        public virtual Category Category { get; set; } = default!;

        /// <summary>
        /// Represents the foreign key to location entity.
        /// </summary>
        public long LocationId { get; set; } = default!;

        public virtual Location Location { get; set; } = default!; 

        /// <summary>
        /// Represents the foreign key to workplace entity.
        /// </summary>
        public long WorkplaceId { get; set; } = default!;

        public virtual Workplace Workplace { get; set; } = default!; 

        /// <summary>
        /// Represents the foreign key to worker entity.
        /// </summary>
        public long WorkerId { get; set; } = default!;

        public virtual Worker Worker { get; set; } = default!; 

        /// <summary>
        /// Represents a unique assetkey of an asset.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string AssetKey { get; set; } = default!;

        /// <summary>
        /// Represents a unique serial number of an asset.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string SerialNumber { get; set; } = default!;

        /// <summary>
        /// Represents a list of conditions of an asset.
        /// </summary>
        public enum Condition
        {
            Functional,
            Malfunctional,
            Inoperable,
            RMA
        }
        /// <summary>
        /// Represents the condition status of an asset.
        /// </summary>
        public Condition AssetState { get; set; } = default!;

        /// <summary>
        /// Represents the date when the asset was aquired.
        /// </summary>
        public DateOnly AcquisitionDate { get; set; } = default!;

        /// <summary>
        /// Represents the usage status of an asset.
        /// </summary>
        [Required]
        public bool IsUsed { get; set; } = default!;

        /// <summary>
        /// Represents the leased status of an asset.
        /// </summary>
        [Required]
        public bool IsLeased { get; set; } = default!;

        /// <summary>
        /// Represents a comment for an asset.
        /// </summary>
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
        [StringLength(250)]
        public string PrimaryImagePath { get; set; } = default!;

        /// <summary>
        /// Represents the path to the picture of the label of an asset.
        /// </summary>
        [StringLength(250)]
        public string SecondaryImagePath { get; set; } = default!;
        #endregion
    }
}
