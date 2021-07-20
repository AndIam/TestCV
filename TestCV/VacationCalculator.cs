using System;
using TestCV.Interfaces;

namespace TestCV
{
    public class VacationCalculator : IVacationDaysCalculator
    {
        IEmployeeRepository _employeeRepository;
        IVacationRepository _vacationRepository;

        public VacationCalculator(IEmployeeRepository employeeRepository, IVacationRepository vacationReository)
        {
            _employeeRepository = employeeRepository;
            _vacationRepository = vacationReository;
        }

        //public double CalculateDay(Guid employeeId, DateTime beginDate, DateTime calculationDate)
        //{
        //    var emp = _employeeRepository.GetEmployee(employeeId);
        //    int workingDaysForPeriod = _vacationRepository.CountWorkLogByType(employeeId, emp.EmploymentDate, calculationDate, WorkLogType.Work);

        //    return workingDaysForPeriod;
        //}

        public double CalculateDay(Guid employeeId, DateTime beginDate, DateTime calculationDate)
        {
            var emp = _employeeRepository.GetEmployee(employeeId);
            var totalDays = _vacationRepository.CalculateTotalDays(employeeId);
            int workingDaysForPeriod = _vacationRepository.CountWorkLogByType(employeeId, emp.EmploymentDate, calculationDate, WorkLogType.Work);

            //if(totalDays < 730) 1ый метод
            //else второй метод

            return workingDaysForPeriod;
        }
    }
}
