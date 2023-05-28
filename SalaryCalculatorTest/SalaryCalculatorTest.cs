using FluentAssertions;
using SalaryCalculator.Calculations;

namespace SalaryCalculatorTest;

public class SalaryCalculatorTest
{
    [Fact]
    public double Amount_After_Calculating_EmployeePension_Should_Be_Greater_Than_Amount_Before()
    {
        double amountBefore = EmployeePension.BasicSalaryCalculatingEmployeePensionContribution(amount: 2000);

        const double Tier2 = 0.055; 
        const double Tier3 = 0.05;  
        double totalEmployeeTiers = Tier2 + Tier3;

        double amountAfter = amountBefore / (1 - totalEmployeeTiers);

        amountAfter.Should().Be(amountBefore / (1 - totalEmployeeTiers));
        return amountAfter;
    }


    [Fact]
    public double Amount_After_Calculating_EmployerPension_Should_Be_Greater_Than_Amount_Before()
    {
        double amountBefore = EmployerPension.BasicSalaryCalculatingEmployerPensionContribution(amount: 2000);

        const double Tier1 = 0.13;
        const double Tier3 = 0.05;
        double totalEmployerTiers = Tier1 + Tier3;

        double amountAfter = amountBefore/(1 - totalEmployerTiers);

        amountAfter.Should().Be(amountBefore / (1 - totalEmployerTiers));
        return amountAfter;
    }

    [Fact]

    public double Amount_After_Accumulating_PayeTax_Should_Be_An_Addition_Of_PayeTax_And_TaxableIncome()
    {
        
        var taxableIncome = PayeTax.CumulativePayeTaxAmount(taxableIncome: 2000);

        double cumulativeAmount = taxableIncome;

        double[] taxRates = { 30, 25, 17.5, 10, 5, 0 };

        double[] chargeableIncome = { 20000, 16461, 3000, 120, 100, 319 };


        for (int i = 0; i < taxRates.Length; i++)
        {
            var amountBeforeTax = (100 * cumulativeAmount) / (100 + taxRates[i]);

            if (amountBeforeTax - chargeableIncome[i] < 0)
            {
                continue;
            }
            else
            {
                cumulativeAmount += (cumulativeAmount - amountBeforeTax);
            }
        }

        return cumulativeAmount;
    }

}
