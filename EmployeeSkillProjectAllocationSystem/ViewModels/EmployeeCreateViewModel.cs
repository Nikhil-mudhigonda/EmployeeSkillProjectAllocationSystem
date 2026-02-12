using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeSkillProjectAllocationSystem.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public string Name { get; set; }

        public List<int> SelectedSkillId {  get; set; } = new List<int>();
        public List<SelectListItem> Skills {  get; set; } = new List<SelectListItem> { };
    }
}
