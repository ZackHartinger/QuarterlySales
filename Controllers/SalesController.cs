using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private QuarterlySalesContext context { get; set; }
        public SalesController(QuarterlySalesContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add(QuarterlySalesViewModel model)
        {
            model.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
            return View("AddSales", model);
        }

        [HttpPost]
        public IActionResult AddToDB(QuarterlySalesViewModel model)
        {
            if (TempData["okSales"] == null)
            {
                string msg = Check.SalesExist(context, model);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError("Sale.EmployeeId", msg);
                }
            }
            if (ModelState.IsValid)
            {
                if (model.Sale.SaleId == 0)
                    context.Sales.Add(model.Sale);
                else
                    context.Sales.Update(model.Sale);

                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
				model.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
				return View("AddSales", model);
			}
        }
    }
}

