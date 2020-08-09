using AutoMapper;
using AutoMapper.QueryableExtensions;
using DormitoryManager.Application.Interfaces;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.Entities;
using DormitoryManager.Data.IRepositories;
using DormitoryManager.Infrastructure.Interfaces;
using DormitoryManager.Utilities.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManager.Application.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IFunctionRepository _functionRepository;
        private readonly IPermissionRepository _permissionRepository; 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IFunctionRepository functionRepository, IPermissionRepository permissionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roleManager = roleManager;
            _functionRepository = functionRepository;
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(AppRoleViewModel roleVm)
        {
            var role = new AppRole()
            {
                Name = roleVm.Name,
                Description = roleVm.Description,
                Type = roleVm.Type,
                ModuleId = roleVm.ModuleId
            };
            var result = await _roleManager.CreateAsync(role);
            //var announcement = _mapper.Map<AnnouncementViewModel, Announcement>(announcementVm);
            //_announcementRepository.Add(announcement);
            //foreach (var userVm in announcementUsers)
            //{
            //    var user = _mapper.Map<AnnouncementUserViewModel, AnnouncementUser>(userVm);
            //    _announcementUserRepository.Add(user);
            //}
            _unitOfWork.Commit();
            return result.Succeeded;
        }

        public async Task<bool> CheckNameExist(string name)
        {
            var model = await _roleManager.FindByNameAsync(name);
            return model != null;
        }

        public Task<bool> CheckPermission(string functionId, string action, string[] roles)
        {
            var functions = _functionRepository.FindAllAsNoTracking();
            var permissions = _permissionRepository.FindAllAsNoTracking();
            var query = from f in functions
                        join p in permissions on f.Id equals p.FunctionId
                        join r in _roleManager.Roles on p.RoleId equals r.Id
                        where roles.Contains(r.Name) && f.Id == functionId
                        && ((p.CanCreate && action == "Create")
                        || (p.CanUpdate && action == "Update")
                        || (p.CanDelete && action == "Delete")
                        || (p.CanRead && action == "Read"))
                        select p;
            return query.AnyAsync();
        }

        public async Task<Guid> GetRoleIdByName(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            return role.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
        }

        public async Task<List<AppRoleViewModel>> GetAllAsync()
        {
            return await _roleManager.Roles.OrderBy(x => x.ModuleId).ThenByDescending(x => x.SortOrder).ProjectTo<AppRoleViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<AppRoleViewModel>> GetAllByModuleIdAsync(int moduleId)
        {
            return await _roleManager.Roles.Where(x => x.ModuleId == moduleId).OrderBy(x => x.ModuleId).ThenByDescending(x => x.SortOrder).ProjectTo<AppRoleViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<AppRoleViewModel>> GetAllExcept_Async(string roleName)
        {
            return await _roleManager.Roles.ProjectTo<AppRoleViewModel>(_mapper.ConfigurationProvider).Where(x => x.Name != roleName).ToListAsync();
        }

        public PagedResult<AppRoleViewModel> GetAllPagingAsync(int? moduleId, string keyword, int page, int pageSize)
        {
            var query = _roleManager.Roles;

            if (moduleId.HasValue)
                query = query.Where(x => x.ModuleId == moduleId);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword));

            int totalRow = query.Count();
            query = query.OrderBy(x => x.ModuleId).ThenByDescending(x => x.SortOrder).Skip((page - 1) * pageSize)
               .Take(pageSize);

            var data = query.ProjectTo<AppRoleViewModel>(_mapper.ConfigurationProvider).ToList();
            var paginationSet = new PagedResult<AppRoleViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public async Task<AppRoleViewModel> GetById(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            return _mapper.Map<AppRole, AppRoleViewModel>(role);
        }

        public List<PermissionViewModel> GetListFunctionWithRole(Guid roleId)
        {
            var functions = _functionRepository.FindAllAsNoTracking();
            var permissions = _permissionRepository.FindAllAsNoTracking();

            var query = from f in functions
                        join p in permissions on f.Id equals p.FunctionId into fp
                        from p in fp.DefaultIfEmpty()
                        where p != null && p.RoleId == roleId
                        select new PermissionViewModel()
                        {
                            RoleId = roleId,
                            FunctionId = f.Id,
                            CanCreate = p != null ? p.CanCreate : false,
                            CanDelete = p != null ? p.CanDelete : false,
                            CanRead = p != null ? p.CanRead : false,
                            CanUpdate = p != null ? p.CanUpdate : false
                        };
            return query.ToList();
        }

        public void SavePermission(List<PermissionViewModel> permissionVms, Guid roleId)
        {
            var permissions = _mapper.Map<List<PermissionViewModel>, List<Permission>>(permissionVms);
            var oldPermission = _permissionRepository.FindAll().Where(x => x.RoleId == roleId).ToList();
            if (oldPermission.Count > 0)
            {
                _permissionRepository.RemoveMultiple(oldPermission);
            }
            foreach (var permission in permissions)
            {
                _permissionRepository.Add(permission);
            }
            _unitOfWork.Commit();
        }

        public async Task UpdateAsync(AppRoleViewModel roleVm)
        {
            var role = await _roleManager.FindByIdAsync(roleVm.Id.ToString());
            role.Description = roleVm.Description;
            role.Name = roleVm.Name;
            role.Type = roleVm.Type;
            role.ModuleId = roleVm.ModuleId;
            role.SortOrder = roleVm.SortOrder;
            await _roleManager.UpdateAsync(role);
        }
    }
}
