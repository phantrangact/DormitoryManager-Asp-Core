using AutoMapper;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        { 
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Student, StudentViewModel>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<Floor, FloorViewModel>();
            CreateMap<Transission, TransissionViewModel>();
        }
    }
}
