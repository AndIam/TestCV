using System;
using System.Collections.Generic;
using System.Linq;
using TestCV.Interfaces;

namespace TestCV.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        private const int ACCOUNTING_DAYS_BY_FULL_VACATION = 730;

        protected List<WorkLog> _workLogs;
        protected List<Employee> _employees;

        public int GetAccountingDaysByFullVacation => ACCOUNTING_DAYS_BY_FULL_VACATION;

        public VacationRepository(List<Employee> employees, List<WorkLog> workLogs)
        {
            _workLogs = workLogs;
            _employees = employees;
        }

        public void AddEmployee(WorkLog workLog)
            => _workLogs.Add(workLog);

        public void DeleteEmployee(Guid id)
        {
            var emp = _workLogs.Where(w => w.Id == id).FirstOrDefault();
            if (emp != null)
                _workLogs.Remove(emp);
        }

        public int CountWorkLogByType(
            Guid employeeId,
            DateTime EmploymentDate,
            DateTime calculationDate,
            WorkLogType type)
        {
            return _workLogs
                .Where(x =>
                    x.EmployeeId == employeeId
                    && x.WorkLogType == type
                    && (x.Date >= EmploymentDate || x.Date <= calculationDate))
                .Count();
        }

        public double GetTotalDays(Guid id)
        {
            var emp = _employees.Where(x => x.Id == id).FirstOrDefault();
            var date = DateTime.Now - emp.EmploymentDate;
            return date.TotalDays;
        }
    }
}
