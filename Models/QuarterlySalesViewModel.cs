namespace QuarterlySales.Models
{
    public class QuarterlySalesViewModel
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Sale Sale { get; set; } = new Sale();
        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
