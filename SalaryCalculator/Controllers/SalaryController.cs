using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalaryCalculator.Calculations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {

        [HttpPost]
        public IActionResult CalculateSalary(SalaryRequest request)
        {
            double amountBeforePensionTaxes = PayeTax.CumulativePayeTaxAmount(request.NetSalary);

            var amountAfterTax = amountBeforePensionTaxes - request.Allowances < 0? 0: amountBeforePensionTaxes - request.Allowances;
            double bothEPCandAAT = EmployeePension.BasicSalaryCalculatingEmployeePensionContribution(amountAfterTax);

            var results = new SalaryResult();
            results.GrossSalary = Math.Round(amountAfterTax + request.Allowances, 2);
            results.EmployeePensionContribution = Math.Round(bothEPCandAAT - amountAfterTax, 2);

            results.PAYETax = Math.Round(amountBeforePensionTaxes - request.NetSalary, 2);
            results.EmployerPensionContribution = Math.Round(EmployerPension.BasicSalaryCalculatingEmployerPensionContribution(bothEPCandAAT - amountAfterTax), 2);

            

            results.BasicSalary = Math.Round(amountAfterTax, 2);

            return Ok(results);
        }
    }
}

