using DormitoryManager.Data.Entities;
using DormitoryManager.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Data.EF.Repositories
{
    public class PermissionRepository : EFRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
