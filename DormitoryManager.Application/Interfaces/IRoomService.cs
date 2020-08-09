using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.Entities;
using DormitoryManager.Utilities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManager.Application.Interfaces
{
    public interface IRoomService : IDisposable
    {
        void Add(RoomViewModel RoomVm);
        void Delete(int id);
        RoomViewModel GetById(int id);
        Task<List<RoomViewModel>> GetAll(string filter);
        void Save();
        void Update(RoomViewModel RoomVm);
        void ReOrder(int RoomId, int targetId);
        PagedResult<RoomViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
        List<RoomViewModel> GetListRoomByFloorId(int id);
    }
}
