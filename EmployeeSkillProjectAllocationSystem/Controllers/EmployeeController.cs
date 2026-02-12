using EmployeeSkillProjectAllocationSystem.Data;
using EmployeeSkillProjectAllocationSystem.Models;
using EmployeeSkillProjectAllocationSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSkillProjectAllocationSystem.Controllers
{
    [Authorize(Roles = "HR")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            var EmpVM = new EmployeeCreateViewModel();

            EmpVM.Skills = await _context.Skills
                .Where(x => x.IsActive)
                .Select(x => new SelectListItem {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToListAsync();
            return View(EmpVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel EmpVM)
        {
            if (!ModelState.IsValid)
            {
                return View(EmpVM);
            }
            var employee = new Employee
            {
                Name = EmpVM.Name
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            foreach(var skillId in EmpVM.SelectedSkillId)
            {
                _context.EmployeeSkills.Add(new EmployeeSkill
                {
                    EmployeeId = employee.Id,
                    skillId = skillId
                });
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
