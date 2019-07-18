using Dividender.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Dividender.Controllers
{
    public class UserMgmtController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserMgmtController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.OrderBy(x => x.Email).ToList();
            return View(users);
        }
    }
}