using devdeer.AssetsManager.Data.Entities.Entities.Base;
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
        public string Label { get; set; } = default!;

        #endregion
    }
}
