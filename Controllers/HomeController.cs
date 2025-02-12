using Microsoft.AspNetCore.Mvc;
using QuarterlySales.Models;
using System.Diagnostics;

namespace QuarterlySales.Controllers
{
	public class HomeController : Controller
	{
		private QuarterlySalesContext context { get; set; }
		public HomeController(QuarterlySalesContext ctx) => context = ctx;

		public IActionResult Index(QuarterlySalesViewModel model)
		{
			if (model.EmployeeId != null && model.EmployeeId != 0)
			{
                model.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
                model.Sales = context.Sales.Where(s => s.EmployeeId == model.EmployeeId)
					.OrderBy(s => s.Quarter)
					.ToList();
				return View(model);
			}
			else
			{
				model.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
				model.Sales = context.Sales.OrderBy(s => s.Quarter).ToList();
				return View(model);
			}
			
		}

		public IActionResult AddSale(QuarterlySalesViewModel model)
		{
			model.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
			return View("AddSales", model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
