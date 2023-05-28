using System;
namespace SalaryCalculator.Calculations
{
	public class EmployeePension
	{/// <summary>
    /// Pass in the amount before tax to calculate the basic salary
    /// </summary>
    /// <param name="amountAfterTax">AmountAfterTax is the amount cumulated when payeTax is added to it and allowances subtracted.</param>
    /// <returns>Amount after employee pension contribution has been added. So we subtract amount after paye tax from this to get the employee pension contribution.</returns>
        public static double AmountCalculatingEmployeePensionContribution(double amountAfterTax)
        {
            //dividing the amount after tax by the percentage left after the employee tax from tier 2 and 3.
            //tax for tier 2 is 5.5% added to tier 3 tax(5%) making a total of 10.5%
            //100% - 10.5% = 89.5% which is equal to 0.895 (percentage left after tax percentage deducted).

            const double Tier2 = 0.055; //5.5%
            const double Tier3 = 0.05;  //5%
            double totalEmployeeTiers = Tier2 + Tier3;


            double percentageAfterDeduction = 1 - totalEmployeeTiers;

            var employeePensionPlusAmountAfterTax = amountAfterTax / percentageAfterDeduction;

            return employeePensionPlusAmountAfterTax;
        }
    }
}