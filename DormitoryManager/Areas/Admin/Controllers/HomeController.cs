using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitoryManager.Application.Implementation;
using DormitoryManager.Application.Interfaces;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        #region fields
        private IStudentService _studentService;
        private IFloorService _floorService;
        private IRoomService _roomService;
        #endregion

        #region constructor
        public HomeController(IStudentService studentService, IFloorService floorService, IRoomService roomService)
        {
            _studentService = studentService;
            _floorService = floorService;
            _roomService = roomService;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetTopStudent()
        {
            string keyword = "";
            int page = 1, pageSize = 10;
            var model = _studentService.GetAllPagingAsync(keyword, page, pageSize);
            if (model.Results != null && model.Results.Any())
            {
                List<StudentViewModel> listStudent = new List<StudentViewModel>();
                foreach (var item in model.Results)
                {
                    FloorViewModel floor = null;
                    RoomViewModel room = null;
                    if (item.FloorId > 0)
                    {
                        floor = _floorService.GetById(item.FloorId);
                    }
                    if (item.RoomId > 0)
                    {
                        room = _roomService.GetById(item.RoomId);
                    }
                    if (floor != null)
                    {
                        item.FloorName = floor.FloorName;
                    }
                    if (room != null)
                    {
                        item.RoomName = room.RoomName;
                    }
                    listStudent.Add(item);
                }
                model.Results = listStudent;
            }
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult GetTopRoom()
        {
            string keyword = "";
            int page = 1, pageSize = 10;
            var model = _roomService.GetAllPagingAsync(keyword, page, pageSize);
            if (model.Results != null && model.Results.Any())
            {
                List<RoomViewModel> listRoom = new List<RoomViewModel>();
                foreach (var item in model.Results)
                {
                    FloorViewModel floor = null;
                    if (item.FloorId > 0)
                    {
                        floor = _floorService.GetById(item.FloorId);
                    }
                    if (floor != null)
                    {
                        item.FloorName = floor.FloorName;
                    }
                    listRoom.Add(item);
                }
                model.Results = listRoom;
            }
            return new OkObjectResult(model);
        }
    }
}