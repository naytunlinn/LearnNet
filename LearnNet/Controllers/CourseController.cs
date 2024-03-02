using LearnNet.Models.ViewModels;
using LearnNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet.Controllers
{
    public class CourseController : Controller
    {
        private readonly IService<CourseViewModel> _courseService;

        public CourseController(IService<CourseViewModel> courseService)
        {
            this._courseService = courseService;
        }
        public IActionResult List() //Show
        {
            return View(_courseService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {

                return View(_courseService.GetById(id));
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
                _courseService.Delete(id);
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
        public IActionResult Entry(CourseViewModel ui)
        {
            try
            {
                _courseService.Create(ui);
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