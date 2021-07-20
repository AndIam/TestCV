using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCV
{
    class EmployeeRepository : IEmployeeRepository
    {
        private IEnumerable<Employee> _employees;
        private IEnumerable<WorkLog> _workLogs;

        public EmployeeRepository(IEnumerable<Employee> employees, IEnumerable<WorkLog> workLogs)
        {
            _employees = employees;
            _workLogs = workLogs;
        }

        public int CountWorkLogByType(
            Guid employeeId, 
            DateTime beginDate, 
            DateTime endDate, 
            WorkLogType type)
        {
            return _workLogs
                .Where(x =>
                    x.EmployeeId == employeeId
                    && x.WorkLogType == type
                    && (x.Date <= endDate || x.Date >= beginDate))
                .Count();
        }

        public Employee GetEmployee(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
