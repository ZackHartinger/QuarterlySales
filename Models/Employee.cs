using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models
{
	public class Employee
	{
		public int EmployeeId { get; set; }

		[Required(ErrorMessage = "Please enter a first name.")]
		[StringLength(50)]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a last name.")]
		[StringLength(50)]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a DOB.")]
		[DataType(DataType.DateTime)]
		public DateTime DOB { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Please enter a hire date.")]
		[DataType(DataType.DateTime)]
		[MinimumHireDate]
		public DateTime HireDate { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Please select a manager from the list.")]
		public int ManagerId { get; set; }

		[ValidateNever]
		public Employee Manager { get; set; } = null!;

		public string FullName 
		{
			get
			{
				return this.FirstName + " " + this.LastName;
			}
		}
	}
}
