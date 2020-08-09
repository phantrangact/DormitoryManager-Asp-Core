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
    public class TransisionService : ITransisionService
    {
        private IRepository<Transission, int> _transissionRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransisionService(IMapper mapper,
            IRepository<Transission, int> transissionRepository,
            IUnitOfWork unitOfWork)
        {
            _transissionRepository = transissionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(TransissionViewModel transissionVm)
        {
            var transission = _mapper.Map<Transission>(transissionVm);
            _transissionRepository.Add(transission);
        }
        public void Delete(int id)
        {
            _transissionRepository.Remove(id);
        }

        public TransissionViewModel GetById(int id)
        {
            var transission = _transissionRepository.FindSingle(x => x.Id == id);
            return _mapper.Map<Transission, TransissionViewModel>(transission);
        }

        public Task<List<TransissionViewModel>> GetAll(string filter)
        {
            var query = _transissionRepository.FindAll(x => x.Status == Status.Active && (string.IsNullOrEmpty(filter) || x.StudentName.Contains(filter) || x.StudentIdentify.Contains(filter)));
            return query.OrderBy(x => x.Id).ProjectTo<TransissionViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TransissionViewModel transissionVm)
        {
            try
            {
                var _transissionMm = _transissionRepository.FindSingle(x => x.Id == transissionVm.Id);
                var transission = _mapper.Map<Transission>(transissionVm);
                _transissionRepository.Update(transission);
            }
            catch (Exception e)
            {
                string str = e.ToString();
            }

        }

        public void ReOrder(int transissionId, int targetId)
        {
            var transission = _transissionRepository.FindById(transissionId);
            var target = _transissionRepository.FindById(targetId);
            int tempOrder = transission.SortOrder;

            transission.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _transissionRepository.Update(transission);
            _transissionRepository.Update(target);
        }
        public PagedResult<TransissionViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _transissionRepository.FindAll(a => string.IsNullOrEmpty(keyword) || a.StudentName.Contains(keyword) || a.StudentIdentify.Contains(keyword));

            int totalRow = query.Count();
            query = query.OrderBy(x => x.Id).ThenByDescending(x => x.SortOrder).Skip((page - 1) * pageSize)
               .Take(pageSize);

            var data = query.ProjectTo<TransissionViewModel>(_mapper.ConfigurationProvider).ToList();
            var paginationSet = new PagedResult<TransissionViewModel>()
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

        PagedResult<TransissionViewModel> ITransisionService.GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
