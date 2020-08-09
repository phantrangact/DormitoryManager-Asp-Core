using AutoMapper;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<AppUserViewModel, AppUser>()
            .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.UserName,
            c.Email, c.PhoneNumber, c.Avatar, c.Status, c.ModifiedBy, c.DateModified, c.DepartmentId, c.CompanyId));

            CreateMap<AppRoleViewModel, AppRole>()
       .ConstructUsing(c => new AppRole(c.Description, c.ModuleId, c.Name, c.Type, c.SortOrder));

            CreateMap<PermissionViewModel, Permission>()
            .ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete));

            CreateMap<FunctionViewModel, Function>()
          .ConstructUsing(c => new Function(c.Name, c.URL, c.ParentId, c.IconCss, c.SortOrder));

            CreateMap<StudentViewModel, Student>()
          .ConstructUsing(c => new Student(c.Id, c.StudentName, c.StudentIdentify, c.Age, c.Class, c.Address, c.Birthday, c.RoomId, c.FloorId, c.LastModify, c.CreateDate, c.LastModifyById, c.LastModifyByName, c.CreateById, c.CreateByName, c.Status, c.SortOrder, c.RoomName, c.FloorName));

            CreateMap<RoomViewModel, Room>()
              .ConstructUsing(c => new Room(c.Id, c.RoomName, c.RoomHeight, c.RoomWidth, c.ElectricityPrice, c.WaterPrice, c.InternetPrice, c.TotalBed, c.TotalEmtyBed, c.TotalUsedBed, c.FloorId, c.FloorName, c.Status, c.SortOrder));

            CreateMap<FloorViewModel, Floor>()
             .ConstructUsing(c => new Floor(c.Id, c.FloorName, c.TotalRoom, c.TotalEmtyRoom, c.Status, c.SortOrder));

            CreateMap<TransissionViewModel, Transission>()
           .ConstructUsing(c => new Transission(c.Id, c.ElectricityPrice, c.WaterPrice, c.InternetPrice, c.TotalMount, c.ReturnMount, c.OwedMount, c.RealMount, c.StudentName, c.StudentIdentify, c.StudentId, c.RoomId, c.FloorId, c.Mounth, c.Year, c.LastModify, c.CreateDate, c.LastModifyById, c.LastModifyByName, c.CreateById, c.CreateByName, c.Status, c.SortOrder));

        }
    }
}
