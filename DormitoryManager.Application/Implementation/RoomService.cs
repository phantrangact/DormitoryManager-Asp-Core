using AutoMapper;
using AutoMapper.QueryableExtensions;
using DormitoryManager.Application.Interfaces;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.Entities;
using DormitoryManager.Data.Enums;
using DormitoryManager.Infrastructure.Interfaces;
using DormitoryManager.Utilities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManager.Application.Implementation
{
    public class RoomService : IRoomService
    {
        private IRepository<Room, int> _RoomRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomService(IMapper mapper,
            IRepository<Room, int> RoomRepository,
            IUnitOfWork unitOfWork)
        {
            _RoomRepository = RoomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(RoomViewModel RoomVm)
        {
            var Room = _mapper.Map<Room>(RoomVm);
            Room.Status = Status.Active;
            _RoomRepository.Add(Room);
        }
        public void Delete(int id)
        {
            _RoomRepository.Remove(id);
        }

        public List<RoomViewModel> GetListRoomByFloorId(int id)
        {
            var query = _RoomRepository.FindAll(x => x.FloorId == id);
            return query.OrderBy(x => x.Id).ProjectTo<RoomViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public RoomViewModel GetById(int id)
        {
            var Room = _RoomRepository.FindSingle(x => x.Id == id);
            return _mapper.Map<Room, RoomViewModel>(Room);
        }

        public Task<List<RoomViewModel>> GetAll(string filter)
        {
            var query = _RoomRepository.FindAllAsNoTracking(x => x.Status == Status.Active && (string.IsNullOrEmpty(filter) || x.RoomName.Contains(filter)));
            return query.OrderBy(x => x.Id).ProjectTo<RoomViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(RoomViewModel RoomVm)
        {
            var roomDb = _RoomRepository.FindById(RoomVm.Id);
            roomDb.RoomName = RoomVm.RoomName;
            roomDb.RoomWidth = RoomVm.RoomWidth;
            roomDb.RoomHeight = RoomVm.RoomHeight;
            roomDb.ElectricityPrice = RoomVm.ElectricityPrice;
            roomDb.InternetPrice = RoomVm.InternetPrice;
            roomDb.WaterPrice = RoomVm.WaterPrice;
            roomDb.TotalBed = RoomVm.TotalBed;
            roomDb.TotalEmtyBed = RoomVm.TotalEmtyBed;
            Save();
        }

        public void ReOrder(int RoomId, int targetId)
        {
            var Room = _RoomRepository.FindById(RoomId);
            var target = _RoomRepository.FindById(targetId);
            int tempOrder = Room.SortOrder;

            Room.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _RoomRepository.Update(Room);
            _RoomRepository.Update(target);
        }
        public PagedResult<RoomViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _RoomRepository.FindAllAsNoTracking(a => string.IsNullOrEmpty(keyword) || a.RoomName.Contains(keyword));

            int totalRow = query.Count();
            query = query.OrderBy(x => x.Id).ThenByDescending(x => x.SortOrder).Skip((page - 1) * pageSize)
               .Take(pageSize);

            var data = query.ProjectTo<RoomViewModel>(_mapper.ConfigurationProvider).ToList();
            var paginationSet = new PagedResult<RoomViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
