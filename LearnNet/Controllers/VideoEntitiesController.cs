using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearnNet.DAO;
using LearnNet.Models.DataModels;

namespace LearnNet.Controllers
{
    public class VideoEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VideoEntities
        public async Task<IActionResult> Index()
        {
              return _context.Videos != null ? 
                          View(await _context.Videos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Videos'  is null.");
        }

        // GET: VideoEntities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var videoEntity = await _context.Videos
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (videoEntity == null)
            {
                return NotFound();
            }

            return View(videoEntity);
        }

        // GET: VideoEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoId,Title,VideoUrl,ModuleId,CourseId,UploadDate,CreatedAt,ModifiedAt")] VideoEntity videoEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoEntity);
        }

        // GET: VideoEntities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var videoEntity = await _context.Videos.FindAsync(id);
            if (videoEntity == null)
            {
                return NotFound();
            }
            return View(videoEntity);
        }

        // POST: VideoEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VideoId,Title,VideoUrl,ModuleId,CourseId,UploadDate,CreatedAt,ModifiedAt")] VideoEntity videoEntity)
        {
            if (id != videoEntity.VideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoEntityExists(videoEntity.VideoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(videoEntity);
        }

        // GET: VideoEntities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var videoEntity = await _context.Videos
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (videoEntity == null)
            {
                return NotFound();
            }

            return View(videoEntity);
        }

        // POST: VideoEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Videos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Videos'  is null.");
            }
            var videoEntity = await _context.Videos.FindAsync(id);
            if (videoEntity != null)
            {
                _context.Videos.Remove(videoEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoEntityExists(string id)
        {
          return (_context.Videos?.Any(e => e.VideoId == id)).GetValueOrDefault();
        }
    }
}
