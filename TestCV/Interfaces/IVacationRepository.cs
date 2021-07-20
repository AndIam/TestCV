using System;
using System.Collections.Generic;
using System.Text;

namespace TestCV.Interfaces
{
    public interface IVacationRepository
    {
        int CountWorkLogByType(Guid employee, DateTime beginDate, DateTime endDate, WorkLogType type);

        double CalculateTotalDays(Guid employeeId);
    }
}
