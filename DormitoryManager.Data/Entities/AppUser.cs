using DormitoryManager.Data.Enums;
using DormitoryManager.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DormitoryManager.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public AppUser() { }


        public AppUser(Guid id, string fullName, string userName, string email, string phoneNumber, string avatar, Status status, string modifiedBy, DateTime? dateModified, int? departmentId, int? companyId)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            Status = status;
            ModifiedBy = modifiedBy;
            DateModified = dateModified;
            DepartmentId = departmentId;
            CompanyId = companyId;
        }

        [StringLength(50)]
        public string FullName { get; set; }

        public DateTime? BirthDay { set; get; }


        [StringLength(255)]
        public string Avatar { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        [StringLength(255)]
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Status Status { get; set; }

        //[StringLength(250)]
        //public string IP { get; set; }

        //public DateTime? AccessDate { get; set; }

        public int? DepartmentId { get; set; }
        public int? CompanyId { get; set; }
    }
}
