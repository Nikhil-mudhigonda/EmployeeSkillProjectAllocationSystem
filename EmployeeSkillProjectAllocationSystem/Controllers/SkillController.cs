using EmployeeSkillProjectAllocationSystem.Data;
using EmployeeSkillProjectAllocationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeSkillProjectAllocationSystem.Controllers
{
    [Authorize(Roles = "HR")]
    public class SkillController : Controller
    {
        public readonly ApplicationDbContext _context;
        public SkillController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var skills = await _context.Skills.OrderBy(x => x.Id).ToListAsync();
            return View(skills);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }
            try
            {
                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Skill already exists");
                return View(skill);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
                return NotFound();
            return View(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Skill skill)
        {
            if(id != skill.Id)
                return NotFound();
            if (!ModelState.IsValid)
                return View(skill);

            try
            {
                _context.Skills.Update(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Skill already exists");
                return View();
            }
        }
    }
}
