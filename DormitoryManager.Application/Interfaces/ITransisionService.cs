using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Utilities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManager.Application.Interfaces
{
    public interface ITransisionService : IDisposable
    {
        void Add(TransissionViewModel stransVm);
        void Delete(int id);
        TransissionViewModel GetById(int id);
        Task<List<TransissionViewModel>> GetAll(string filter);
        void Save();
        void Update(TransissionViewModel stransVm);
        void ReOrder(int studentId, int targetId);
        PagedResult<TransissionViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
    }
}
