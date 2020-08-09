using DormitoryManager.Application.Interfaces;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Extensions;
using DormitoryManager.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DormitoryManager.Areas.Admin.Components
{
    [Area("Admin")]
    [Authorize]
    public class StudentViewComponent : ViewComponent
    {
        private readonly IStudentService _studentService;
        private readonly IRoomService _roomService;
        private readonly IFloorService _floorService;
        public StudentViewComponent(IStudentService studentService, IFloorService floorService, IRoomService roomService)
        {
            _roomService = roomService;
            _floorService = floorService;
            _studentService = studentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<FloorViewModel> listFloor =  await _floorService.GetAll(null);
            return View(listFloor);
        }
    }
}
