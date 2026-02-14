using EmployeeSkillProjectAllocationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSkillProjectAllocationSystem.Controllers
{
    public class ProjectTeamController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProjectTeamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var projTeam = _context.Projects
                .Where(x => x.isActive)
                .Include(x => x.EmployeeProjects)
                .ThenInclude(x => x.Employee);
            //var EMP = new EmployeeSkillProjectAllocationSystem.ViewModels.EmployeeProjectViewModel();
            //EMP.Employees = await _context.Employees.Where(x => x.IsActive).Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name
            //}).ToListAsync();

            //EMP.Projects = await _context.Projects.Where(x => x.isActive).Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name
            //}).ToListAsync();

            //return View(EMP);
            return View(projTeam);
        }
    }
}
