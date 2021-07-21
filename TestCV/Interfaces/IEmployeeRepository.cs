using System;

namespace TestCV
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(Guid id);
    }
}
