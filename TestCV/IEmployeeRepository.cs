using System;
using System.Collections.Generic;
using System.Text;

namespace TestCV
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(Guid id);

        int CountWorkLogByType(Guid employee, DateTime beginDate, DateTime endDate, WorkLogType type);
    }
}
