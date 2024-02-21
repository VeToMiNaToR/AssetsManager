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
    /// Represents an Asset in the DataStore.
    /// </summary>
    [Table(nameof(Asset), Schema = "BaseData")]
    public class Asset : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Represents the Foreign Key to Brand Entity.
        /// </summary>
        [Required]
        public long BrandId { get; set; } = default!;
        public virtual Brand Brand { get; set; } = default!; //Navigation Property.

        /// <summary>
        /// Represents the Foreign Key to Category Entity.
        /// </summary>
        public long CategoryId { get; set; } = default!;
        public virtual Category Category { get; set; } = default!; //Navigation Property.

        /// <summary>
        /// Represents the Foreign Key to Location Entity.
        /// </summary>
        public long LocationId { get; set; } = default!;
        public virtual Location Location { get; set; } = default!; //Navigation Property.

        /// <summary>
        /// Represents the Foreign Key to Workplace Entity.
        /// </summary>
        public long WorkplaceId { get; set; } = default!;
        public virtual Workplace Workplace { get; set; } = default!; //Navigation Property.

        /// <summary>
        /// Represents the Foreign Key to Worker Entity.
        /// </summary>
        public long WorkerId { get; set; } = default!;
        public virtual Worker Worker { get; set; } = default!; //Navigation Property.

        /// <summary>
        /// Represents a Unique AssetKey of an Asset.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string AssetKey { get; set; } = default!;

        /// <summary>
        /// Represents a Unique Serial Number of an Asset.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string SerialNumber { get; set; } = default!;

        /// <summary>
        /// Represents the Condition Status of an Asset.
        /// </summary>
        [Required]
        public bool Condition { get; set; } = default!;

        /// <summary>
        /// Represents the Date when the Asset was Aquired.
        /// </summary>
        public DateOnly AcquisitionDate { get; set; } = default!;

        /// <summary>
        /// Represents the Usage Status of an Asset.
        /// </summary>
        [Required]
        public bool IsUsed { get; set; } = default!;

        /// <summary>
        /// Represents the Leased Status of an Asset.
        /// </summary>
        [Required]
        public bool IsLeased { get; set; } = default!;

        /// <summary>
        /// Represents a Comment for an Asset.
        /// </summary>
        public string Comment { get; set; } = default!;

        /// <summary>
        /// Represents the Name of the Model of an Asset.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ModelName { get; set; } = default!;

        /// <summary>
        /// Represents the Path to the Picture of an Asset.
        /// </summary>
        [Required]
        public string PrimaryImagePath { get; set; } = default!;

        /// <summary>
        /// Represents the Path to the Picture of the Label of an Asset.
        /// </summary>
        [StringLength(100)]
        public string SecondaryImagePath { get; set; } = default!;
        #endregion
    }
}
