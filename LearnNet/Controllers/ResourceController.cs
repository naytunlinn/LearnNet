using LearnNet.Models.ViewModels;
using LearnNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet.Controllers
{
    public class ResourceController : Controller
    {
        private readonly IService<ResourceViewModel> _resourceService;

        public ResourceController(IService<ResourceViewModel> resourceService)
        {
            this._resourceService = resourceService;
        }
        public IActionResult List() //Show
        {
            return View(_resourceService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {

                return View(_resourceService.GetById(id));
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
                _resourceService.Delete(id);
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
        public IActionResult Entry(ResourceViewModel ui)
        {
            try
            {
                _resourceService.Create(ui);
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