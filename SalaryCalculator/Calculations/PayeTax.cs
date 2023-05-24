using System;
namespace SalaryCalculator.Calculations
{
	public class PayeTax
	{/// <summary>
     /// This method takes the income which is to be taxed and matches it to the chargeable income values and determines what rates applies to it.
     /// </summary>
     /// <param name="taxableIncome"></param>
     /// <returns></returns>
        public static double ReversePayeTax(double taxableIncome)
        {
            //assigning incoming taxable income to a new variable for the calculations.
            double cumulativeTax = taxableIncome;

            //this is in percentage.
            double[] taxRates = { 30, 25, 17.5, 10, 5, 0 };

            //first 319 cedis, on and on to amount exceeding 20,000 cedis
            double[] chargeableIncome = { 20000, 16461, 3000, 120, 100, 319 };


            for (int i = 0; i < taxRates.Length; i++)
            {
                var amountBeforeTax = (100 * cumulativeTax) / (100 + taxRates[i]);

                if (amountBeforeTax - chargeableIncome[i] < 0)
                {
                    continue;
                }
                else
                {
                    cumulativeTax += (cumulativeTax - amountBeforeTax);
                }
            }

            return cumulativeTax;
        }

    }
}

