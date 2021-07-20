using System;
using System.Collections.Generic;
using System.Text;

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
                FirstDayOnTheWorking = DateTime.UtcNow.AddYears(-10)
            };

            var yesterday = DateTime.UtcNow.AddYears(-1);
            var vacationYesterday = new WorkLog
            {
                EmployeeId = employee.Id,
                Date = yesterday.Date,
                WorkLogType = WorkLogType.Vacation
            };

            var repository = new EmployeeRepository(new[] { employee }, new[] { vacationYesterday });
            var calculator = new VacationCalculator(repository);

            var result = calculator.CalculateDay(employee.Id, employee.FirstDayOnTheWorking, yesterday);
            Console.WriteLine("Count {0}", result);

        }
    }
}
