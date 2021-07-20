using System;
using System.Collections.Generic;
using System.Text;

namespace TestCV
{
    public class VacationCalculator : IVacationDaysCalculator
    {
        IEmployeeRepository _employeeRepository;

        public VacationCalculator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public int CalculateDay(Guid employeeId, DateTime beginDate, DateTime endDate)
        {
            int workingDaysForPeriod = _employeeRepository.CountWorkLogByType(employeeId, beginDate, endDate);
            return workingDaysForPeriod / 10;
        }
    }
}
