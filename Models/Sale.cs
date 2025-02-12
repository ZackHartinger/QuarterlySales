using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models
{
	public class Sale
	{
		public int SaleId { get; set; }

		[Required(ErrorMessage = "Please enter a quarter.")]
		[Range(1, 4, ErrorMessage = "Quarter must be between 1 and 4")]
		public int Quarter { get; set; } = 1;

		[Required(ErrorMessage = "Please enter a year.")]
		[Range(2000, 9999, ErrorMessage = "Year must be after 2000.")]
		public int Year { get; set; } = DateTime.Now.Year;

		[Required(ErrorMessage = "Please enter an amount.")]
		public decimal Amount { get; set; } 

		[Required(ErrorMessage = "Please select and employee.")]
		public int EmployeeId { get; set; }

		[ValidateNever]
		public Employee Employee { get; set; } = null!;
	}
}
