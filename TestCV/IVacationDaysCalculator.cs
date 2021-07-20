using System;
using System.Collections.Generic;
using System.Text;

namespace TestCV
{
    public interface IVacationDaysCalculator
    {
        int CalculateDay(Guid employeeId, DateTime beginDate, DateTime endDate);
    }
}
