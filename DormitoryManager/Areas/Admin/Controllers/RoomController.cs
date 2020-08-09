using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitoryManager.Application.Interfaces;
using DormitoryManager.Application.ViewModels.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DormitoryManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll(string filter)
        {
            var result = await _roomService.GetAll(filter);
            return new OkObjectResult(result);
        }

        public IActionResult GetById(int id)
        {
            var result = _roomService.GetById(id);
            return new OkObjectResult(result);
        }

        public IActionResult GetAllPaging(string keyword, int page, int pagesize)
        {
            var result = _roomService.GetAllPagingAsync(keyword, page, pagesize);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public IActionResult SaveEntity(RoomViewModel roomVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (roomVm.Id == 0)
                {

                    roomVm.DateCreated = DateTime.Now;
                    roomVm.CreatedBy = User.Identity.Name;

                    _roomService.Add(roomVm);
                }
                else
                {

                    roomVm.DateModified = DateTime.Now;
                    roomVm.ModifiedBy = User.Identity.Name;
                    _roomService.Update(roomVm);
                }
            }

            _roomService.Save();

            return new OkObjectResult(roomVm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _roomService.Delete(id);
            _roomService.Save();
            return new OkObjectResult(id);
        }
    }
}