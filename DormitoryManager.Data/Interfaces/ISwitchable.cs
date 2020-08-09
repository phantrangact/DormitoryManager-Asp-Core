using DormitoryManager.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
