using AutoMapper.Configuration.Annotations;
using DormitoryManager.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DormitoryManager.Application.ViewModels.System
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string StudentName { get; set; }
        [Required]
        public string StudentIdentify { get; set; }
        [Required]
        public int Age { get; set; }
        public string Class { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [Required]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        [Required]
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public DateTime LastModify { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifyById { get; set; }
        public string LastModifyByName { get; set; }
        public string CreateById { get; set; }
        public string CreateByName { get; set; }
        public Status Status { get; set; }
        public int SortOrder { get; set; }
    }
}
