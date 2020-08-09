using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Application.ViewModels.System
{
    public class AppRoleViewModel
    {
        public Guid? Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public int? Type { get; set; }

        public int? SortOrder { get; set; }

        public int? ModuleId { get; set; }
    }
}
