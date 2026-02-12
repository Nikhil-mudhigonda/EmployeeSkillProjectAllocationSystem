using System.ComponentModel.DataAnnotations;

namespace EmployeeSkillProjectAllocationSystem.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool isActive { get; set; } = true;
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
