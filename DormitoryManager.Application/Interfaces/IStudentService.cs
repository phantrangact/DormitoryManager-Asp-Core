using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.Entities;
using DormitoryManager.Utilities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManager.Application.Interfaces
{
    public interface IStudentService : IDisposable
    {
        void Add(StudentViewModel studentVm);
        void Delete(int id);
        StudentViewModel GetById(int id);
        Task<List<StudentViewModel>> GetAll(string filter);
        void Save();
        void Update(StudentViewModel studentVm);
        void ReOrder(int studentId, int targetId);
        PagedResult<StudentViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
    }
}
