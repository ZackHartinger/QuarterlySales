namespace QuarterlySales.Models
{
	public class Check
	{
		public static string EmployeeExists(QuarterlySalesContext ctx, QuarterlySalesViewModel model)
		{
			string msg = string.Empty;
			if (!string.IsNullOrEmpty(model.Employee.FullName))
			{
				var employee = ctx.Employees.FirstOrDefault(
					e => e.FirstName.ToLower() == model.Employee.FirstName.ToLower() &&
						e.LastName.ToLower() == model.Employee.LastName &&
						e.DOB == model.Employee.DOB);
				if (employee != null)
					msg = $"{model.Employee.FullName} ({model.Employee.DOB}) is already in the database.";
			}
			return msg;
		}

		public static string IsManager(QuarterlySalesContext ctx, QuarterlySalesViewModel model)
		{
			string msg = string.Empty;
			if (!string.IsNullOrEmpty(model.Employee.FullName))
			{
				var employee = ctx.Employees.FirstOrDefault(
					e => e.Manager.FirstName.ToLower() == model.Employee.FirstName.ToLower() &&
						e.Manager.LastName.ToLower() == model.Employee.LastName);
				if (employee != null)
					msg = $"Manager and employee can't be the same person.";
			}
			return msg;
		}

		public static string SalesExist(QuarterlySalesContext ctx, QuarterlySalesViewModel model)
		{
			string msg = string.Empty;
			if (!string.IsNullOrEmpty(model.Sale.EmployeeId.ToString()))
			{
				model.Employee = ctx.Employees.FirstOrDefault(
					e => e.EmployeeId == model.Sale.EmployeeId);

				var employeeSale = ctx.Sales.FirstOrDefault(
					s => s.Employee.EmployeeId == model.Sale.EmployeeId &&
						s.Year == model.Sale.Year &&
						s.Quarter == model.Sale.Quarter);
				if (employeeSale != null)
					msg = $"Sales for {model.Employee.FullName} for {model.Sale.Year} Q{model.Sale.Quarter} are already in the database.";
			}
			return msg;
		}
	}
}
