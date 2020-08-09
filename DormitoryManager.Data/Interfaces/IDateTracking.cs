using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Data.Interfaces
{
    public interface IDateTracking
    {
        string CreatedBy { get; set; }

        DateTime DateCreated { set; get; }

        string ModifiedBy { get; set; }

        DateTime? DateModified { set; get; }
    }
}
