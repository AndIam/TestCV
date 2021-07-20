using System;
using System.Collections.Generic;
using TestCV.Repositories;

namespace TestCV
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Andrew",
                EmploymentDate = DateTime.UtcNow.AddYears(-10)
            };

            var listOfEmployees = new List<Employee>();
            var listOfWorkLogs = new List<WorkLog>();

            var yesterday = DateTime.UtcNow.AddYears(-1);
            var vacationYesterday = new WorkLog
            {
                EmployeeId = employee.Id,
                Date = yesterday.Date,
                WorkLogType = WorkLogType.Work
            };

            listOfEmployees.Add(employee);
            listOfWorkLogs.Add(vacationYesterday);

            var repositoryOfEmployee = new EmployeeRepository(listOfEmployees, listOfWorkLogs);
            var repositoryOfVacation = new VacationRepository(listOfEmployees, listOfWorkLogs);
            
            var calculator = new VacationCalculator(repositoryOfEmployee, repositoryOfVacation);

            var result = calculator.CalculateDay(employee.Id, employee.EmploymentDate, yesterday);

            Console.WriteLine("Count {0}", result);

            var totalDays = repositoryOfVacation.CalculateTotalDays(employee.Id);

            Console.WriteLine(totalDays);

        }
    }
}
