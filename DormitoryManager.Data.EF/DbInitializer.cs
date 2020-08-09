using DormitoryManager.Data.Entities;
using DormitoryManager.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManager.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
            }

            if (!_userManager.Users.Any())
            {

                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    CreatedBy = "admin",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active
                }, "123456");

            }

            var user = await _userManager.FindByNameAsync("admin");
            await _userManager.AddToRoleAsync(user, "Admin");

            if (_context.Functions.Count() == 0)
            {
                _context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "Hệ thống", ParentId = null, SortOrder = 1, Status = Status.Active, URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "STUDENT", Name = "Quản lý sinh viên", ParentId = "SYSTEM", SortOrder = 2, Status = Status.Active, URL = "/admin/student/index",IconCss = "fa-user"  },
                    new Function() {Id = "TRANSISSION", Name = "Thống kê chi phí", ParentId = "SYSTEM", SortOrder = 3, Status = Status.Active, URL = "/admin/transission/index",IconCss = "fa-bar-chart"  },
                    new Function() {Id = "FLOOR", Name = "Tầng", ParentId = "SYSTEM", SortOrder = 4, Status = Status.Active, URL = "/admin/floor/index",IconCss = "fa-home"  },
                    new Function() {Id = "ROOM", Name = "Phòng", ParentId = "SYSTEM", SortOrder = 5, Status = Status.Active,URL = "/admin/room/index",IconCss = "fa-bed"  },
                    new Function() {Id = "USER", Name = "Người dùng", ParentId = "SYSTEM", SortOrder = 1, Status = Status.Active,URL = "/admin/user/index",IconCss = "fa-user"  },


                    //new Function() {Id = "REPORT",Name = "Báo cáo",ParentId = null,SortOrder = 5,Status = Status.InActive,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Báo cáo doanh thu",ParentId = "REPORT",SortOrder = 1,Status = Status.InActive,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  }
                });
                await _context.SaveChangesAsync();
            }


            if (!_context.Permissions.Any())
            {
                var roles = _context.AppRoles.ToList();

                //_context.Permissions.AddRange(new List<Permission>()
                //    {
                       
                //    });
            }
            await _context.SaveChangesAsync();
        }
    }
}
