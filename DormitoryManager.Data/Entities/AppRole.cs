using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace DormitoryManager.Data.Entities
{
    [Table("AppRoles")]
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base()
        {

        }

        public AppRole(string roleName, int? moduleId, string name, int? type, int? sortOrder) : base(roleName)
        {
            ModuleId = moduleId;
            Name = name;
            Type = type;
            SortOrder = sortOrder;
        }

        [StringLength(250)]
        public string Description { get; set; }

        [DefaultValue(1)]
        public int? Type { get; set; }

        public int? SortOrder { get; set; }

        public int? ModuleId { get; set; }
    }
}
