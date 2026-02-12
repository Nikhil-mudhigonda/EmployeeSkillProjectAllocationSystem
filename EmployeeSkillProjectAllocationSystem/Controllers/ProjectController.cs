using EmployeeSkillProjectAllocationSystem.Data;
using EmployeeSkillProjectAllocationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeSkillProjectAllocationSystem.Controllers
{
    public class ProjectController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects.OrderBy(x => x.Id).ToListAsync();
            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Project already exists");
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return View();
            }
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            if(id != project.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
