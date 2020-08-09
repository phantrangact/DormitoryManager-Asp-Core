using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DormitoryManager.Application.ViewModels.System
{
    public class CustomerViewModel
    {

        //public CustomerViewModel(int? id, string fullName, string creatorNote, Guid creatorId, string saleNote, Guid saleId, DateTime? deal, decimal price, DateTime? dateSendByCustomer, string phoneNumber, string createdBy, DateTime dateCreated, string modifiedBy, DateTime? dateModified, bool isDelete, int status)
        //{
        //    Id = id;
        //    FullName = fullName;
        //    CreatorNote = creatorNote;
        //    CreatorId = creatorId;
        //    SaleNote = saleNote;
        //    SaleId = saleId;
        //    Deal = deal;
        //    Price = price;
        //    DateSendByCustomer = dateSendByCustomer;
        //    PhoneNumber = phoneNumber;
        //    CreatedBy = createdBy;
        //    DateCreated = dateCreated;
        //    ModifiedBy = modifiedBy;
        //    DateModified = dateModified;
        //    this.isDelete = isDelete;
        //    Status = status;
        //}

        public int? Id { get; set; }
        public string FullName { get; set; }
        public string CreatorNote { get; set; }//note cua ng tao
        public string CreatorName { get; set; }//ten nguoi tao
        public Guid CreatorId { get; set; }//id cua nguoi tao
        public string SaleNote { get; set; }//note cua sale
        public Guid SaleId { get; set; }//id sale
        public string SaleName { get; set; }//ten cua sale
        public DateTime? Deal { get; set; }//thoi gian chot deal
        [DefaultValue(0)]
        public decimal Price { get; set; }//don gia
        public DateTime? DateSendByCustomer { get; set; }//thoi gian khach hang gui sdt
        public string PhoneNumber { get; set; }//sdt
        [StringLength(50)]
        public string CreatedBy { get; set; }//nguoi tao ban ghi

        public DateTime DateCreated { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }
        [DefaultValue(false)]
        public bool isDelete { get; set; }
        public int Status { get; set; } //status chot don, chua chot,...
    }
}
