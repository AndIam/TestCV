using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCV.Interfaces;

namespace TestCV.Repositories
{
    public class VacationRepository : IVacationReository
    {
        protected List<WorkLog> _workLogs;
        public VacationRepository(List<WorkLog> workLogs)
            => _workLogs = workLogs;

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
            DateTime beginDate,
            DateTime calculationDate,
            WorkLogType type)
        {
            return _workLogs
                .Where(x =>
                    x.EmployeeId == employeeId
                    && x.WorkLogType == type
                    && (x.Date >= beginDate || x.Date <= calculationDate))
                .Count();
        }
    }
}
