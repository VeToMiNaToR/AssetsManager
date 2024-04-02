namespace devdeer.AssetsManager.Data.Entities.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Libraries.Abstractions.BaseTypes;

    /// <summary>
    /// Represents the worker of an asset in the datastore.
    /// </summary>
    [Table(nameof(Worker), Schema = "BaseData")]
    public class Worker : BaseEntity
    {
        #region properties

        /// <summary>
        /// Represents the name of a worker of an asset.
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Label { get; set; } = default!;

        #endregion
    }
}