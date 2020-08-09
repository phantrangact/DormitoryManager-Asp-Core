using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitoryManager.Application.Interfaces;
using DormitoryManager.Application.ViewModels.System;
using DormitoryManager.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DormitoryManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FloorController : Controller
    {
        private readonly IFloorService _floorService;
        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll(string filter)
        {
            var result = await _floorService.GetAll(filter);
            return new OkObjectResult(result);
        }

        public IActionResult GetById(int id)
        {
            var result = _floorService.GetById(id);
            return new OkObjectResult(result);
        }

        public IActionResult GetAllPaging(string keyword, int page, int pagesize)
        {
            var result = _floorService.GetAllPagingAsync(keyword, page, pagesize);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public IActionResult SaveEntity(FloorViewModel floorVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }else
            {
                if (floorVm.Id == 0)
                {

                    floorVm.DateCreated = DateTime.Now;
                    floorVm.CreatedBy = User.Identity.Name;

                    _floorService.Add(floorVm);
                }
                else
                {

                    floorVm.DateModified = DateTime.Now;
                    floorVm.ModifiedBy = User.Identity.Name;
                    _floorService.Update(floorVm);
                }
            }

            

            _floorService.Save();

            return new OkObjectResult(floorVm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _floorService.Delete(id);
            _floorService.Save();
            return new OkObjectResult(id);
        }
    }
}