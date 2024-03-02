using LearnNet.Models.ViewModels;
using LearnNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet.Controllers
{
    public class VideoController : Controller
    {
        private readonly IService<VideoViewModel> _videoService;

        public VideoController(IService<VideoViewModel> videoService)
        {
            this._videoService = videoService;
        }
        public IActionResult List() //Show
        {
            return View(_videoService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {

                return View(_videoService.GetById(id));
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
                _videoService.Delete(id);
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
        public IActionResult Entry(VideoViewModel ui)
        {
            try
            {
                _videoService.Create(ui);
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