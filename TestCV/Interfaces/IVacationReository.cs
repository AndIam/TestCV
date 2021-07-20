using System;
using System.Collections.Generic;
using System.Text;

namespace TestCV.Interfaces
{
    public interface IVacationReository
    {
        int CountWorkLogByType(Guid employee, DateTime beginDate, DateTime endDate, WorkLogType type);

    }
}
