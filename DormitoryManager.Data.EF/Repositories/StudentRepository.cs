using System;
using System.Collections.Generic;
using System.Text;
using DormitoryManager.Data.Entities;
using DormitoryManager.Data.IRepositories;

namespace DormitoryManager.Data.EF.Repositories
{
    public class StudentRepository : EFRepository<Student, int>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
