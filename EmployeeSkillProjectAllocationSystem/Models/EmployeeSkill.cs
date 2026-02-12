namespace EmployeeSkillProjectAllocationSystem.Models
{
    public class EmployeeSkill
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int skillId { get; set; }    
        public Skill skill { get; set; }
    }
}
