using DormitoryManager.Data.Entities;
using DormitoryManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DormitoryManager.Data.IRepositories
{
    public interface IRoomRepository : IRepository<Room, int>
    {
        
    }
}
