using DormitoryManager.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Application.ViewModels.System
{
    public class TransissionViewModel
    {
        public TransissionViewModel(int id, decimal electricityPrice, decimal waterPrice, decimal internetPrice, decimal totalMount, decimal returnMount, decimal owedMount, decimal realMount, string studentName, string studentIdentify, int studentId, int roomId, int floorId, int mounth, int year, DateTime lastModify, DateTime createDate, string lastModifyById, string lastModifyByName, string createById, string createByName, Status status, int sortOrder)
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

        public int Id { get; set; }
        public decimal ElectricityPrice { get; set; }
        public decimal WaterPrice { get; set; }
        public decimal InternetPrice { get; set; }
        public decimal TotalMount { get; set; }
        public decimal ReturnMount { get; set; }
        public decimal OwedMount { get; set; }
        public decimal RealMount { get; set; }
        public string StudentName { get; set; }
        public string StudentIdentify { get; set; }
        public int StudentId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public DateTime LastModify { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifyById { get; set; }
        public string LastModifyByName { get; set; }
        public string CreateById { get; set; }
        public string CreateByName { get; set; }
        public Status Status { get; set; }
        public int SortOrder
        {
            get; set;
        }
    }
}