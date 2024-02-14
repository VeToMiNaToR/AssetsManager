using Azure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Data.Entities
{
    public class DataEntries
    {
        [Key]
        public string InventoryCode { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string BrandName { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Description { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string SerialNumber { get; set; } = default!;

        [StringLength(50)]
        public Stream DeviceImage { get; set; } = default!;

        [StringLength(50)]
        public Stream ImageOfDeviceSticker { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Location { get; set; } = default!;

        [StringLength(50)]
        public string Workplace { get; set; } = default!;

        [StringLength(50)]
        public string AssignedTo { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string ConditionStatus { get; set; } = default!;

        [StringLength(50)]
        public DateOnly AcquisitionDate { get; set; } = default!;

        [Required]
        public bool UsageStatus {  get; set; } = default!;

        [Required]
        public bool LeasedDevice {  get; set; } = default!;

        [StringLength(100)]
        public string Commentary { get; set; } = default!;
    }
}
