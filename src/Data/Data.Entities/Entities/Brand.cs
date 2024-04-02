﻿namespace devdeer.AssetsManager.Data.Entities.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Libraries.Abstractions.BaseTypes;

    /// <summary>
    /// Represents the brand of an asset in the datastore.
    /// </summary>
    [Table(nameof(Brand), Schema = "BaseData")]
    public class Brand : BaseEntity
    {
        #region properties

        /// <summary>
        /// Represents the name of the brand of an asset.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Label { get; set; } = default!;

        #endregion
    }
}