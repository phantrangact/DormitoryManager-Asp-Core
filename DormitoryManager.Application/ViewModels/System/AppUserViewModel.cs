using DormitoryManager.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DormitoryManager.Application.ViewModels.System
{
    public class AppUserViewModel
    {
        public AppUserViewModel()
        {
            Roles = new List<string>();
        }
        public Guid? Id { set; get; }
        public string FullName { set; get; }
        public string BirthDay { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string Address { get; set; }
        public string PhoneNumber { set; get; }
        public string Avatar { get; set; }
        public Status Status { get; set; }

        public string Gender { get; set; }

        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(255)]
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public List<string> Roles { get; set; }

        //public string IP { get; set; }

        //public DateTime? AccessDate { get; set; }

        public int? DepartmentId { get; set; }
        public int? CompanyId { get; set; }
    }

}
