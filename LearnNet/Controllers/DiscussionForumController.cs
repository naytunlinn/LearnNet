using LearnNet.Models.ViewModels;
using LearnNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet.Controllers
{
    public class DiscussionForumController : Controller
    {
        private readonly IService<DiscussionForumViewModel> _discussionforumService;

        public DiscussionForumController(IService<DiscussionForumViewModel> discussionforumService)
        {
            this._discussionforumService = discussionforumService;
        }
        public IActionResult List() //Show
        {
            return View(_discussionforumService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {

                return View(_discussionforumService.GetById(id));
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
                _discussionforumService.Delete(id);
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
        public IActionResult Entry(DiscussionForumViewModel ui)
        {
            try
            {
                _discussionforumService.Create(ui);
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