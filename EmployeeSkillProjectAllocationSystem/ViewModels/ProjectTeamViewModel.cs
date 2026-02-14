using EmployeeSkillProjectAllocationSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeSkillProjectAllocationSystem.ViewModels
{
    public class ProjectTeamViewModel
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string Role { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
