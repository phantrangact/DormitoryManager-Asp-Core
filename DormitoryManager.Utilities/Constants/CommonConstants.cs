using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Utilities.Constants
{
    public class CommonConstants
    {
        public const string DefaultFooterId = "DefaultFooterId";

        public const string DefaultContactId = "default";

        //public const string CartSession = "CartSession";

        public const string TopPosition = "top";

        public const int ProductNews = 1;
        public const int RecruitmentNews = 2;
        public const string NewsTag = "News";

        public class Module
        {
            public const int PhanHeTong = 1;
            public const int QuanLyAnToan = 2;
            public const int QuanLyCongNhan = 3;
            public const int QuanLyThiCong = 4;
            public const int QuanLyVatTu = 5;
            public const int QuanLyCongViec = 6;
        }

        public class AppRole
        {
            public const string MarketingRole = "Marketing";    // Ban Tổng Giám Đốc
            public const string AdminRole = "Admin";        // Quản trị viên
            public const string SaleStaffRole = "SaleStaff";        // Trưởng ban an toàn
        }


        public class UserClaims
        {
            public const string Roles = "Roles";
        }
    }
}
