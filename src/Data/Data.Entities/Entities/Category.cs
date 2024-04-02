﻿
using devdeer.Libraries.Abstractions.BaseTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Data.Entities.Entities
{
    /// <summary>
    /// Represents the category of an asset in the datastore.
    /// </summary>
    [Table(nameof(Category), Schema = "BaseData")]
    public class Category : BaseEntity
    {
        #region properties

        /// <summary>
        /// Represents the name of the location of an asset.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Label { get; set; } = default!;

        #endregion
    }
}