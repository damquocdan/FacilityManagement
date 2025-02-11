using FacilityManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Areas.AdminManagement.Controllers {

    public class DashboardController : BaseController
    {
        private readonly FacilityManagementContext _context;

        public DashboardController(FacilityManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }

}
