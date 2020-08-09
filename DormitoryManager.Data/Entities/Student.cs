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
    [Table("Student")]
    public class Student : DomainEntity<int>, ISwitchable, ISortable
    {
        public Student()
        {
        }

        public Student(int id, string studentName, string studentIdentify, int age, string @class, string address, DateTime birthday, int roomId, int floorId, DateTime lastModify, DateTime createDate, string lastModifyById, string lastModifyByName, string createById, string createByName, Status status, int sortOrder, string roomName, string floorName)
        {
            Id = id;
            StudentName = studentName;
            StudentIdentify = studentIdentify;
            Age = age;
            Class = @class;
            Address = address;
            Birthday = birthday;
            RoomId = roomId;
            FloorId = floorId;
            LastModify = lastModify;
            CreateDate = createDate;
            LastModifyById = lastModifyById;
            LastModifyByName = lastModifyByName;
            CreateById = createById;
            CreateByName = createByName;
            Status = status;
            SortOrder = sortOrder;
            RoomName = roomName;
            FloorName = floorName;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
        public string StudentName { get; set; }
        [StringLength(250)]
        public string StudentIdentify { get; set; }
        public int Age { get; set; }
        [StringLength(250)]
        public string Class { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public int RoomId { get; set; }
        [StringLength(250)]
        public string RoomName { get; set; }
        public int FloorId { get; set; }
        [StringLength(250)]
        public string FloorName { get; set; }
        public DateTime LastModify { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifyById { get; set; }
        [StringLength(250)]
        public string LastModifyByName { get; set; }
        public string CreateById { get; set; }
        [StringLength(250)]
        public string CreateByName { get; set; }
        public Status Status { get; set; }
        public int SortOrder { get; set; }
    }
}
