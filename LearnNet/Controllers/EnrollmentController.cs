using LearnNet.Models.ViewModels;
using LearnNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IService<EnrollmentViewModel> _enrollmentService;

        public EnrollmentController(IService<EnrollmentViewModel> enrollmentService)
        {
            this._enrollmentService = enrollmentService;
        }
        public IActionResult List() //Show
        {
            return View(_enrollmentService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {

                return View(_enrollmentService.GetById(id));
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
                _enrollmentService.Delete(id);
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
        public IActionResult Entry(EnrollmentViewModel ui)
        {
            try
            {
                _enrollmentService.Create(ui);
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