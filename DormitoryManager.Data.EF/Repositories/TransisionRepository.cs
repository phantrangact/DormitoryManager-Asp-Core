using DormitoryManager.Data.Entities;
using DormitoryManager.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Data.EF.Repositories
{
    class TransisionRepository : EFRepository<Transission, int>, ITransisionRepository
    {
        public TransisionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
