using _140123_Homework.Models;

namespace _140123_Homework.ViewModels
{
    public class EmployeeTerritoryViewModel
    {
     
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }   
        public string TerritoryDescription { get; set; }
        
        public List<Employee> employees { get; set; }
        public List<Territory> territories { get; set; }

        
        
    }
}
