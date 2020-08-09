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
    //Tầng của ký túc xá
    [Table("Floor")]
    public class Floor : DomainEntity<int>, ISwitchable, ISortable, IDateTracking
    {
        public Floor()
        {
        }

        public Floor(int id, string floorName, int totalRoom, int totalEmtyRoom, Status status, int sortOrder)
        {
            Id = id;
            FloorName = floorName;
            TotalRoom = totalRoom;
            TotalEmtyRoom = totalEmtyRoom;
            Status = status;
            SortOrder = sortOrder;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string FloorName { get; set; }
        public int TotalRoom { get; set; }
        public int TotalEmtyRoom { get; set; }
        public Status Status { get; set; }
        public int SortOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
