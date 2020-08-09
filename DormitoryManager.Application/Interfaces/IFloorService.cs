using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.Entities;
using DormitoryManager.Utilities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManager.Application.Interfaces
{
    public interface IFloorService : IDisposable
    {
        void Add(FloorViewModel FloorVm);
        void Delete(int id);
        FloorViewModel GetById(int id);
        Task<List<FloorViewModel>> GetAll(string filter);
       
        void Save();
        void Update(FloorViewModel FloorVm);
        void ReOrder(int FloorId, int targetId);
        PagedResult<FloorViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
    }
}
