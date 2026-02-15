using EmployeeSkillProjectAllocationSystem.Data;
using EmployeeSkillProjectAllocationSystem.Models;
using EmployeeSkillProjectAllocationSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSkillProjectAllocationSystem.Controllers
{
    [Authorize(Roles ="Manager, HR")]
    public class EmployeeProjectController : Controller
    {
        public readonly ApplicationDbContext _context;
        public EmployeeProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Index", "Employee", new { area = "" });
        }

        public async Task<IActionResult> Create()
        {
            var EMP = new EmployeeProjectViewModel();
            EMP.Employees = await _context.Employees.Where(x => x.IsActive).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToListAsync();

            EMP.Projects = await _context.Projects.Where(x => x.isActive).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToListAsync();

            return View(EMP);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeProjectViewModel EPvm)
        {
            if (!ModelState.IsValid)
            {
                return View(EPvm);
            }
            var EmployeeProject = new EmployeeProject
            {
                EmployeeId = EPvm.EmployeeId,
                ProjectId = EPvm.ProjectId,
                Role = EPvm.Role
            };

            _context.EmployeeProjects.Add(EmployeeProject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
