using System;
using TestCV.Interfaces;

namespace TestCV
{
    public class VacationCalculator : IVacationDaysCalculator
    {
        const double COEFFICIENT_TO_FULL_VACATION = 0.07;
        const double COEFFICIENT_TO_NOT_FULL_VACATION = 0.066;

        IEmployeeRepository _employeeRepository;
        IVacationRepository _vacationRepository;

        public VacationCalculator(IEmployeeRepository employeeRepository, IVacationRepository vacationReository)
        {
            _employeeRepository = employeeRepository;
            _vacationRepository = vacationReository;
        }

        private bool IsFullVacation(Guid employeeId)
        {
            var totalDaysInCompany = _vacationRepository.GetTotalDays(employeeId);
            return totalDaysInCompany > _vacationRepository.GetAccountingDaysByFullVacation;
        }

        private double CalculateDay(Guid employeeId, DateTime beginDate, DateTime calculationDate)
        {
            var emp = _employeeRepository.GetEmployee(employeeId);
            int workingDaysForPeriod = _vacationRepository.CountWorkLogByType(employeeId, emp.EmploymentDate, calculationDate, WorkLogType.Work);
            int sickingDaysForPeriod = _vacationRepository.CountWorkLogByType(employeeId, emp.EmploymentDate, calculationDate, WorkLogType.Sick);
            int ownDaysForPeriod = _vacationRepository.CountWorkLogByType(employeeId, emp.EmploymentDate, calculationDate, WorkLogType.Unpaid);
            int dayOffDaysForPeriod = _vacationRepository.CountWorkLogByType(employeeId, emp.EmploymentDate, calculationDate, WorkLogType.DayOff);

            return workingDaysForPeriod + sickingDaysForPeriod - ownDaysForPeriod - dayOffDaysForPeriod;
        }

        public double CalculateVacationDays(Guid employeeId, DateTime beginDate, DateTime calculationDate)
        {
            var calculateDays = CalculateDay(employeeId, beginDate, calculationDate);
            if (IsFullVacation(employeeId))
            {
                return calculateDays * COEFFICIENT_TO_FULL_VACATION;
            }

            return calculateDays * COEFFICIENT_TO_NOT_FULL_VACATION;

        }
    }
}
