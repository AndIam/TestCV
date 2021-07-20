using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCV
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        private List<WorkLog> _workLogs;

        public EmployeeRepository(List<Employee> employees, List<WorkLog> workLogs)
        {
            _employees = employees;
            _workLogs = workLogs;
        }
        public void AddEmployee(Employee employee) 
            => _employees.Add(employee);

        public void DeleteEmployee(Guid id)
        {
            var emp = _employees.Where(w => w.Id == id).FirstOrDefault();
            if (emp != null)
                _employees.Remove(emp);
        }


        public Employee GetEmployee(Guid id) 
            => _employees.Where(x => x.Id == id).FirstOrDefault();

    }
}
