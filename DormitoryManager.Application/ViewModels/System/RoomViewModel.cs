using DormitoryManager.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Application.ViewModels.System
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public double RoomHeight { get; set; }
        public double RoomWidth { get; set; }
        public decimal ElectricityPrice { get; set; }
        public decimal WaterPrice { get; set; }
        public decimal InternetPrice { get; set; }
        public int TotalBed { get; set; }
        public int TotalEmtyBed { get; set; }
        public int TotalUsedBed { get; set; }
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public Status Status { get; set; }
        public int SortOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
