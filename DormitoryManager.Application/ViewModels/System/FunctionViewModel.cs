using DormitoryManager.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DormitoryManager.Application.ViewModels.System
{
    public class FunctionViewModel
    {
        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        [Required]
        [StringLength(250)]
        public string URL { set; get; }


        [StringLength(128)]
        public string ParentId { set; get; }

        [StringLength(50)]
        public string IconCss { get; set; }

        public int SortOrder { set; get; }

        public Status Status { set; get; }

        [StringLength(50)]
        public string PhanHe { get; set; }


        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }


        [StringLength(50)]
        public string CssClass { get; set; }
        [StringLength(50)]
        public string Action { get; set; }
        [StringLength(50)]
        public string Controller { get; set; }
    }
}
