
# README.md

A tax calculation system in which an employee can input their net salary and allowances and then the system generates or calculates the corresponding gross salary, paye tax, employee pension tiers contribution, employer pension tier contribution and the basic salary of the employee.


## Tech Stack

**Client:** Swagger Ui

**Server:** .NET Core


## Features

- Cross platform


## Input Parameters
The api has two input parameters which are the net salary of the employee and the allowances of the the employee.

## API Reference

#### Post all items

  Requests made by client


| Property | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Net Salary` | `double` | Net salary input from the client.|
| `Allowances` | `double` | Allowances input from the client. |

#### Get items


Get all results and return them to client

| Property | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Gross Salary`      | `double` | Gross salary output to the client. |
| `Basic Salary`      | `double` | Basic salary output to the client. |
| `Paye Tax`      | `double` | Paye Tax amount output to the client. |
| `Employee Pension`      | `double` | Total employee pension contribution output to the client. |
| `Employer Pension`      | `double` | Total employer pension contribution output to the client. |

#### CalculaterSalary(SalaryRequest resquest)

Takes the requests from the client which are the net salary and allowances and then returns the results / responses which are; paye tax amount, employee and employer pension contribution, basic and gross salaries. Results are all rounded up to two decimal places.

#### EmployerPensionContribution(employeePensionPlusAmountAfterTax - amountAfterTax)

Takes the employeePensionPlusAmountAfterTax - amountAfterTax and then returns the employer pension contribution.

#### AmountCalculatingEmployeePensionContribution(amountAfterTax)

Takes in the amount after paye tax has been calculated and then returns the employee pension contribution in addition to the amount after tax.

#### CumulativePayeTaxAmount(taxableincome)

Takes in the net salary and then reverse calculate it to get a cumulative amount after all taxes have been added and returns cumulative amount which includes the netsalary plus the taxes amount.


**How to run the project :** Download the zip into your directory.
#### Terminal
```http
  cd SalaryCalculator
```
Open Visual Studio and run the project or run:
```http
  dotnet run --project SalaryCalculator/SalaryCalculator.csproj
```

