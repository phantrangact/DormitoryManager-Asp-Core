using DormitoryManager.Data.Entities;
using DormitoryManager.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Data.EF.Repositories
{
    public class RoomRepository : EFRepository<Room, int>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {

        }
    }
}
