using DormitoryManager.Data.Enums;
using DormitoryManager.Data.Interfaces;
using DormitoryManager.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DormitoryManager.Data.Entities
{

    //Phòng trọ
    [Table("Room")]
    public class Room : DomainEntity<int>, ISwitchable, ISortable, IDateTracking
    {
        public Room()
        {
        }

        public Room(int id, string roomName, double roomHeight, double roomWidth, decimal electricityPrice, decimal waterPrice, decimal internetPrice, int totalBed, int totalEmtyBed, int totalUsedBed, int floorId, string floorName, Status status, int sortOrder)
        {
            Id = id;
            RoomName = roomName;
            RoomHeight = roomHeight;
            RoomWidth = roomWidth;
            ElectricityPrice = electricityPrice;
            WaterPrice = waterPrice;
            InternetPrice = internetPrice;
            TotalBed = totalBed;
            TotalEmtyBed = totalEmtyBed;
            TotalUsedBed = totalUsedBed;
            FloorId = floorId;
            FloorName = floorName;
            Status = status;
            SortOrder = sortOrder;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
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
        [ForeignKey("FloorId")]
        public Floor Floor { get; set; }

    }
}
