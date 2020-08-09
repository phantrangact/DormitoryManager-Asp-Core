using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Data.Enums
{

    public enum Status
    {
        InActive,
        Active
    }

    public enum CustomerStatus
    {
        Null,
        CallBack,
        SendLater,
        NoAnswer,
        HaveAdvised,
        ClosedDeal,
        Cancel,
        Confirm
    }
}
