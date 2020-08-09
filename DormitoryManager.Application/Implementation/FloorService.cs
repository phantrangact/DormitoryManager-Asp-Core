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
    public class FloorService : IFloorService
    {
        private IRepository<Floor, int> _FloorRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FloorService(IMapper mapper,
            IRepository<Floor, int> FloorRepository,
            IUnitOfWork unitOfWork)
        {
            _FloorRepository = FloorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(FloorViewModel FloorVm)
        {
            var Floor = _mapper.Map<Floor>(FloorVm);
            Floor.Status = Status.Active;
            _FloorRepository.Add(Floor);
        }
        public void Delete(int id)
        {
            _FloorRepository.Remove(id);
        }

        public FloorViewModel GetById(int id)
        {
            var floor = _FloorRepository.FindSingle(x => x.Id == id);
            return _mapper.Map<Floor, FloorViewModel>(floor);
        }

        public Task<List<FloorViewModel>> GetAll(string filter)
        {
            var query = _FloorRepository.FindAll(x => x.Status == Status.Active && (string.IsNullOrEmpty(filter) || x.FloorName.Contains(filter)));
            return query.OrderBy(x => x.Id).ProjectTo<FloorViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(FloorViewModel floorVm)
        {
            var floorDb = _FloorRepository.FindById(floorVm.Id);
            floorDb.FloorName = floorVm.FloorName;
            floorDb.TotalRoom = floorVm.TotalRoom;
            floorDb.TotalEmtyRoom = floorVm.TotalEmtyRoom;
            Save();
        }

        public void ReOrder(int floorId, int targetId)
        {
            var floor = _FloorRepository.FindById(floorId);
            var target = _FloorRepository.FindById(targetId);
            int tempOrder = floor.SortOrder;

            floor.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _FloorRepository.Update(floor);
            _FloorRepository.Update(target);
        }
        public PagedResult<FloorViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _FloorRepository.FindAll(a => string.IsNullOrEmpty(keyword) || a.FloorName.Contains(keyword));

            int totalRow = query.Count();
            query = query.OrderBy(x => x.Id).ThenByDescending(x => x.SortOrder).Skip((page - 1) * pageSize)
               .Take(pageSize);

            var data = query.ProjectTo<FloorViewModel>(_mapper.ConfigurationProvider).ToList();
            var paginationSet = new PagedResult<FloorViewModel>()
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
