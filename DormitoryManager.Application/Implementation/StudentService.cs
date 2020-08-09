using AutoMapper;
using AutoMapper.QueryableExtensions;
using DormitoryManager.Application.Interfaces;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.EF;
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
    public class StudentService : IStudentService
    {
        private IRepository<Student, int> _studentRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IMapper mapper,
            IRepository<Student, int> studentRepository,
            IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(StudentViewModel studentVm)
        {
            var student = _mapper.Map<Student>(studentVm);
            _studentRepository.Add(student);
        }
        public void Delete(int id)
        {
            _studentRepository.Remove(id);
        }

        public StudentViewModel GetById(int id)
        {
            var student = _studentRepository.FindSingle(x => x.Id == id);
            return _mapper.Map<Student, StudentViewModel>(student);
        }

        public Task<List<StudentViewModel>> GetAll(string filter)
        {
            var query = _studentRepository.FindAll(x => x.Status == Status.Active && (string.IsNullOrEmpty(filter) || x.StudentName.Contains(filter)));
            return query.OrderBy(x => x.Id).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(StudentViewModel studentVm)
        {
            try
            {
                var _studentMm = _studentRepository.FindSingle(x => x.Id == studentVm.Id);
                var student = _mapper.Map<Student>(studentVm);
                _studentRepository.Update(student);
            }
            catch(Exception e)
            {
                string str = e.ToString();
            }
          
        }

        public void ReOrder(int studentId, int targetId)
        {
            var student = _studentRepository.FindById(studentId);
            var target = _studentRepository.FindById(targetId);
            int tempOrder = student.SortOrder;

            student.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _studentRepository.Update(student);
            _studentRepository.Update(target);
        }
        public PagedResult<StudentViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _studentRepository.FindAll(a=>string.IsNullOrEmpty(keyword)|| a.StudentName.Contains(keyword));

            int totalRow = query.Count();
            query = query.OrderBy(x => x.Id).ThenByDescending(x => x.SortOrder).Skip((page - 1) * pageSize)
               .Take(pageSize);

            var data = query.ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToList();
            var paginationSet = new PagedResult<StudentViewModel>()
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
