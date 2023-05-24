using System;
namespace SalaryCalculator.Models
{
	public class SalaryResult
	{
        
        public double GrossSalary { get; set; }
        public double BasicSalary { get; set; }
        public double PAYETax { get; set; }
        public double EmployeePensionContribution { get; set; }
        public double EmployerPensionContribution { get; set; }

    }
}

