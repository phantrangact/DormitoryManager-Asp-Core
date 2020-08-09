using DormitoryManager.Data.Entities;
using DormitoryManager.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Data.EF.Repositories
{
    public class FloorRepository : EFRepository<Floor, int>, IFloorRepository
    {
        public FloorRepository(AppDbContext context) : base(context)
        {

        }
    }
}
