using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeSkillProjectAllocationSystem.ViewModels
{
    public class EmployeeProjectViewModel
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string Role { get; set;  }
        public List<SelectListItem> Employees { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Projects { get; set;} = new List<SelectListItem>();
    }
}
