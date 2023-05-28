using System;
namespace SalaryCalculator.Calculations
{
	public class EmployerPension
	{/// <summary>
     /// Pass in the amount before tax to calculate the basic salary
     /// </summary>
     /// <param name="amount">Amount here is the subtraction of amount after paye tax from the cumulation of both employee pension contribution and amount after tax</param>
     /// <returns>The employer pension contribution after dividing the amount by the tiers percentage</returns>
        public static double EmployerPensionContribution(double amount)
        {
            //dividing the amount before tax by the percentage left after the employer tax from tier 1 and 3.
            //tax for tier 1 is 13% added to tier 3 tax(5%) making a total of 18%.
            //100% - 18% = 82% which is equal to 0.82 (percentage left after tax percentage deducted).


            const double Tier1 = 0.13;
            const double Tier3 = 0.05;
            double totalEmployerTiers = Tier1 + Tier3;

            double percentageAfterDeduction = 1 - totalEmployerTiers;

            var employerPensionAmount = amount / percentageAfterDeduction;

            return employerPensionAmount;
        }
    }
}

