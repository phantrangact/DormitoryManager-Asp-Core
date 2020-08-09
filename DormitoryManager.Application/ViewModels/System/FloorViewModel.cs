using DormitoryManager.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Application.ViewModels.System
{
    public class FloorViewModel
    {
        public int Id { get; set; }
        public string FloorName { get; set; }
        public int TotalRoom { get; set; }
        public int TotalEmtyRoom { get; set; }
        public Status Status { get; set; }
        public int SortOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
