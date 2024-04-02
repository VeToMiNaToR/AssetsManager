namespace devdeer.AssetsManager.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Entities;

    using Libraries.Abstractions.BaseTypes;

    using Logic.Common;

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
        /// Represents the data of the related brand.
        /// </summary>
        public virtual Brand Brand { get; set; } = default!;

        /// <summary>
        /// Represents the foreign key to category entity.
        /// </summary>
        [Required]
        public long CategoryId { get; set; } = default!;

        /// <summary>
        /// Represents the data of the related category.
        /// </summary>
        public virtual Category Category { get; set; } = default!;

        /// <summary>
        /// Represents the foreign key to location entity.
        /// </summary>
        [Required]
        public long LocationId { get; set; } = default!;

        /// <summary>
        /// Represents the data of the related location.
        /// </summary>
        public virtual Location Location { get; set; } = default!;

        /// <summary>
        /// Represents the foreign key to workplace entity.
        /// </summary>
        public long? WorkplaceId { get; set; }

        /// <summary>
        /// Represents the data of the related workplace.
        /// </summary>
        public virtual Workplace Workplace { get; set; } = default!;

        /// <summary>
        /// Represents the foreign key to worker entity.
        /// </summary>
        public long? WorkerId { get; set; }

        /// <summary>
        /// Represents the data of the related worker.
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