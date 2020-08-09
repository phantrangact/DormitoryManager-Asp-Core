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
    [Table("Transassion")]
    public class Transission : DomainEntity<int>, ISwitchable, ISortable
    {
        public Transission(int id, decimal electricityPrice, decimal waterPrice, decimal internetPrice, decimal totalMount, decimal returnMount, decimal owedMount, decimal realMount, string studentName, string studentIdentify, int studentId, int roomId, int floorId, int mounth, int year, DateTime lastModify, DateTime createDate, string lastModifyById, string lastModifyByName, string createById, string createByName, Status status, int sortOrder)
        {
            Id = id;
            ElectricityPrice = electricityPrice;
            WaterPrice = waterPrice;
            InternetPrice = internetPrice;
            TotalMount = totalMount;
            ReturnMount = returnMount;
            OwedMount = owedMount;
            RealMount = realMount;
            StudentName = studentName;
            StudentIdentify = studentIdentify;
            StudentId = studentId;
            RoomId = roomId;
            FloorId = floorId;
            Mounth = mounth;
            Year = year;
            LastModify = lastModify;
            CreateDate = createDate;
            LastModifyById = lastModifyById;
            LastModifyByName = lastModifyByName;
            CreateById = createById;
            CreateByName = createByName;
            Status = status;
            SortOrder = sortOrder;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal ElectricityPrice { get; set; }
        public decimal WaterPrice { get; set; }
        public decimal InternetPrice { get; set; }
        public decimal TotalMount { get; set; }
        public decimal ReturnMount { get; set; }
        public decimal OwedMount { get; set; }
        public decimal RealMount { get; set; }
        [StringLength(100)]
        public string StudentName { get; set; }
        [StringLength(100)]
        public string StudentIdentify { get; set; }
        public int StudentId { get; set; }
        public int RoomId { get; set; }
        public int FloorId { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public DateTime LastModify { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifyById { get; set; }
        [StringLength(100)]
        public string LastModifyByName { get; set; }
        public string CreateById { get; set; }
        [StringLength(100)]
        public string CreateByName { get; set; }
        public Status Status { get; set; }
        public int SortOrder { get; set; }
    }
}
