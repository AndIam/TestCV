using System;
using System.Collections.Generic;
using System.Text;

namespace TestCV
{
    public interface IVacationDaysCalculator
    {
        double CalculateVacationDays(Guid employeeId, DateTime beginDate, DateTime calculationDate);
    }
}
