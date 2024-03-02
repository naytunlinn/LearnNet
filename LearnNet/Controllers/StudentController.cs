using LearnNet.DAO;
using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Controllers
{
    public class StudentController : Controller
    {
        private readonly IService<StudentViewModel> _studentService;

        public StudentController(IService<StudentViewModel> studentService)
        {
            this._studentService = studentService;
        }

        public async Task<IActionResult> List() //Show
        {
            return View(await _studentService.GetAll());
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id != null)
            {
                return View(await _studentService.GetById(id));
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _studentService.Delete(id);
                TempData["Info"] = "Delete Successfully";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error Occur When Deleting Record!";
            }
            return RedirectToAction("List");
        }

        public IActionResult Entry() => View();

        [HttpPost]
        public async Task<IActionResult> Entry(StudentViewModel ui)
        {
            try
            {
                await _studentService.Create(ui);
                TempData["info"] = "successfully save a record to the system";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            // return View();
            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(StudentViewModel ui)
        {
            try
            {
                await _studentService.Update(ui);

                TempData["info"] = "Update process is completed successfully.";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("List");
        }
    }
}