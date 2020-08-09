using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitoryManager.Application.Interfaces;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DormitoryManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IRoomService _roomService;
        private readonly IFloorService _floorService;
        private UserManager<AppUser> _userManager;
        public StudentController(IStudentService studentService, IFloorService floorService, IRoomService roomService, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _roomService = roomService;
            _floorService = floorService;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll(string keyWord)
        {
            var model = await _studentService.GetAll(keyWord);
            return new OkObjectResult(model);
        }

        public  IActionResult GetById(int id)
        {
            var model = _studentService.GetById(id);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public  IActionResult GetListRoom(int floorId)
        {
            var model = _roomService.GetListRoomByFloorId(floorId);
            return new OkObjectResult(model);
        }


        [HttpPost]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEntity(StudentViewModel studentVm)
        {
            AppUser user = await GetMemberFromSession();
            ModelState.Remove("Id"); // to omit SomeValue Validation Error
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }

            if (studentVm.Id == 0)
            {
                DateTime now = DateTime.Now;

                studentVm.Age = Int32.Parse(now.Subtract(studentVm.Birthday).TotalDays / 365 + "");
                studentVm.CreateDate = now;
                studentVm.LastModify = now;
                studentVm.CreateById = user.Id.ToString();
                studentVm.LastModifyById = user.Id.ToString();

                _studentService.Add(studentVm);
            }
            else
            {
                DateTime now = DateTime.Now;
                StudentViewModel currStudent = _studentService.GetById(studentVm.Id);
                studentVm.CreateDate = currStudent.CreateDate;
                studentVm.CreateById = currStudent.CreateById;
                studentVm.CreateByName = currStudent.CreateByName;
                studentVm.Age = (int)(now.Subtract(studentVm.Birthday).TotalDays / 365);
                studentVm.LastModify = now;
                studentVm.LastModifyById = user.Id.ToString();

                _studentService.Update(studentVm);
            }
            _studentService.Save();
            return new OkObjectResult(studentVm);
        }

        public async Task<AppUser> GetMemberFromSession()
        {
            var user = await _userManager.GetUserAsync(User);
            return user;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            _studentService.Delete(id);
            return new OkObjectResult(id);
        }

    }
}
