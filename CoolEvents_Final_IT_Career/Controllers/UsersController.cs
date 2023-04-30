using CoolEvents_Final_IT_Career.Data;
using CoolEvents_Final_IT_Career.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CoolEvents_Final_IT_Career.Areas.Identity.Pages.Account.RegisterModel;

namespace CoolEvents_Final_IT_Career.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly IUserStore<Users> _userStore;

        public UsersController(ApplicationDbContext context, UserManager<Users> userManager, IUserStore<Users> userStore)
        {
            _userStore = userStore;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Users != null ?
                        View(await _context.Users.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var Users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Users == null)
            {
                return NotFound();
            }

            return View(Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public async Task<IActionResult> Create(InputModel input)
        {
            var user = new Users { UserName = input.Username, FirstName = input.FirstName, LastName = input.LastName };

            await _userStore.SetUserNameAsync(user, input.Username, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, input.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(input);
        }
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Users user)
        {
            var editedUser = await _context.Users.FindAsync(user.Id);
            if (editedUser != null)
            {
                if (ModelState.IsValid)
                {
                    editedUser.LastName = user.LastName; editedUser.FirstName = user.FirstName;
                    editedUser.UserName = user.UserName;

                    _context.Update(editedUser);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var Users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Users == null)
            {
                return NotFound();
            }

            return View(Users);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var Users = await _context.Users.FindAsync(id);
            if (Users != null)
            {
                _context.Users.Remove(Users);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
