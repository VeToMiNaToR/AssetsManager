using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Models
{
    public class DataEntriesModel
    {
        public string InventoryCode { get; set; } = default!;

        public string BrandName { get; set; } = default!;

        public Category Type { get; set; } 

        public enum Category
        {
            Monitor,
            Router,
            Smartphone,
            Keyboard,
            Mouse,
            Webcam,
            Tablet,
            Switch
        }

        public string Description { get; set; } = default!;

        public string SerialNumber { get; set; } = default!;

        public Stream DeviceImage { get; set; } = default!;

        public Stream ImageOfDeviceSticker { get; set; } = default!;

        public Location Section { get; set; }

        public enum Location
        {
            [EnumMember(Value = "Büro Magdeburg")]
            BueroMagdeburg,

            [EnumMember(Value = "Zuhause bei")]
            ZuhauseBei,

            [EnumMember(Value = "Mobil (wechselnd)")]
            MobilWechselnd
        }
        private int _workplace;

        public int Workplace
        {
            get => _workplace;
            set
            {
                if (value >= 1 && value <= 20)
                {
                    _workplace = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Workplace must be a number between 1 and 20");
                }
            }
        }
        public enum WorkplaceType
        {
        Office,
        Remote,
        Field,
        HomeOffice
        }
        public WorkplaceType SelectedWorkplace { get; set; }

        public string AssignedTo { get; set; } = default!;

        public DateOnly AcquisitionDate { get; set; }  

        public bool UsageStatus {  get; set; }
        
        public bool LeasedDevice { get; set; }

        public string Commentary { get; set; } = default!;
    }
}
