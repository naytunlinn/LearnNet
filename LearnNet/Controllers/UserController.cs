using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public UserController(ApplicationDbContext applicationDbContext)
		{
			this._applicationDbContext = applicationDbContext;
		}

		// GET: User
		public async Task<IActionResult> Index()
		{
			return _applicationDbContext.UserEntities != null ?
						View(await _applicationDbContext.UserEntities.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.UserEntities'  is null.");
		}

		// GET: User/Details/5
		public async Task<IActionResult> Details(string id)
		{
			if (id == null || _applicationDbContext.UserEntities == null)
			{
				return NotFound();
			}

			var userEntity = await _applicationDbContext.UserEntities
				.FirstOrDefaultAsync(m => m.UserId == id);
			if (userEntity == null)
			{
				return NotFound();
			}

			return View(userEntity);
		}

		// GET: User/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: User/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("UserId,UserName,Email,CreatedAt,ModifiedAt")] UserEntity userEntity)
		{
			if (ModelState.IsValid)
			{
				_applicationDbContext.Add(userEntity);
				await _applicationDbContext.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(userEntity);
		}

		// GET: User/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _applicationDbContext.UserEntities == null)
			{
				return NotFound();
			}

			var userEntity = await _applicationDbContext.UserEntities.FindAsync(id);
			if (userEntity == null)
			{
				return NotFound();
			}
			return View(userEntity);
		}

		// POST: User/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, UserEntity userEntity)
		{
			if (id != userEntity.UserId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_applicationDbContext.Update(userEntity);
					await _applicationDbContext.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!UserEntityExists(userEntity.UserId))
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
			return View(userEntity);
		}

		// GET: User/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _applicationDbContext.UserEntities == null)
			{
				return NotFound();
			}

			var userEntity = await _applicationDbContext.UserEntities
				.FirstOrDefaultAsync(m => m.UserId == id);
			if (userEntity == null)
			{
				return NotFound();
			}

			return View(userEntity);
		}

		// POST: User/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_applicationDbContext.UserEntities == null)
			{
				return Problem("Entity set 'ApplicationDbContext.UserEntities'  is null.");
			}
			var userEntity = await _applicationDbContext.UserEntities.FindAsync(id);
			if (userEntity != null)
			{
				_applicationDbContext.UserEntities.Remove(userEntity);
			}

			await _applicationDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool UserEntityExists(string id)
		{
			return (_applicationDbContext.UserEntities?.Any(e => e.UserId == id)).GetValueOrDefault();
		}
	}
}