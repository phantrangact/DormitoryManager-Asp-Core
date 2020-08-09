using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Utilities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManager.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userVm);

        Task DeleteAsync(string id);

        Task<List<AppUserViewModel>> GetAllAsync();

        Task<List<AppUserViewModel>> GetAllSale();

        PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetById(Guid id);

        Task UpdateAsync(AppUserViewModel userVm);
    }
}
