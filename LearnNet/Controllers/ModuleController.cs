using LearnNet.Models.ViewModels;
using LearnNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IService<ModuleViewModel> _moduleService;

        public ModuleController(IService<ModuleViewModel> moduleService)
        {
            this._moduleService = moduleService;
        }
        public IActionResult List() //Show
        {
            return View(_moduleService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {

                return View(_moduleService.GetById(id));
            }
            else
            {
                return RedirectToAction("List");
            }
        }
        public IActionResult Delete(string id)
        {
            try
            {
                _moduleService.Delete(id);
                TempData["Info"] = "Save Successfully";
            }
            catch (Exception ex)
            {
                TempData["Info"] = "Error Occur When Deleting";
            }
            return RedirectToAction("List");
        }
        public IActionResult Entry() => View();
        [HttpPost]
        public IActionResult Entry(ModuleViewModel ui)
        {
            try
            {
                _moduleService.Create(ui);
                ViewBag.Info = "successfully save a record to the system";
            }
            catch (Exception ex)
            {
                ViewBag.Info = "Error occur when  saving a record  to the system";
            }
            return View();
        }
    }
}