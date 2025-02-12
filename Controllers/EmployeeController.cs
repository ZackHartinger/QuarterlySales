using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
	[Authorize]
    public class EmployeeController : Controller
    {
        private QuarterlySalesContext context { get; set; }
        public EmployeeController(QuarterlySalesContext ctx) => context = ctx;

		[HttpGet]
		public IActionResult Add(QuarterlySalesViewModel model)
		{
			model.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
			return View("AddEmployee", model);
		}
		[HttpPost]
		public IActionResult AddToDB(QuarterlySalesViewModel model)
		{
			if (TempData["okEmployee"] == null)
			{
				string msg = Check.EmployeeExists(context, model);
				if (!String.IsNullOrEmpty(msg))
				{
					ModelState.AddModelError("Employee.DOB", msg);
				}

				string managerMsg = Check.IsManager(context, model);
				if (!String.IsNullOrEmpty(managerMsg))
				{
					ModelState.AddModelError("Employee.ManagerId", managerMsg);
				}
			}
			if (ModelState.IsValid)
			{
				if (model.Employee.EmployeeId == 0)
					context.Employees.Add(model.Employee);
				else
					context.Employees.Update(model.Employee);

				context.SaveChanges();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				model.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
				return View("AddEmployee", model);
			}
		}
	}
}

