using DormitoryManager.Data.Entities;
using DormitoryManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Data.IRepositories
{
    public interface IStudentRepository: IRepository<Student, int>
    {
    }
}
