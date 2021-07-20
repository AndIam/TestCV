using System;
using System.Collections.Generic;
using System.Text;
using TestCV.Interfaces;

namespace TestCV
{
    public class VacationCalculator : IVacationDaysCalculator
    {
        IEmployeeRepository _employeeRepository;
        IVacationReository _vacationReository;

        public VacationCalculator(IEmployeeRepository employeeRepository, IVacationReository vacationReository)
        {
            _employeeRepository = employeeRepository;
            _vacationReository = vacationReository;
        }

        public double CalculateDay(Guid employeeId, DateTime beginDate, DateTime calculationDate)
        {
            var emp = _employeeRepository.GetEmployee(employeeId);
            int workingDaysForPeriod = _vacationReository.CountWorkLogByType(employeeId, emp.EmploymentDate, calculationDate, WorkLogType.Work);

            return workingDaysForPeriod / 10;
        }

    }
}
