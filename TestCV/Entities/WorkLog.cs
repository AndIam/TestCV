using System;

namespace TestCV
{
    public class WorkLog
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public WorkLogType WorkLogType { get; set; }
    }
}
