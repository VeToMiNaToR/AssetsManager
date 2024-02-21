using devdeer.AssetsManager.Data.Entities.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Data.Entities.Entities
{
    public class Workplace : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = default!;
    }
}
