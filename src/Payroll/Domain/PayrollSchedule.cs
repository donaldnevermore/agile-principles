using System;

namespace AgileSoftwareDevelopment.Payroll.Domain {
    public interface PayrollSchedule {
        bool IsPayDate(DateTime payDate);
        DateTime GetPayPeriodStartDate(DateTime date);
    }
}
