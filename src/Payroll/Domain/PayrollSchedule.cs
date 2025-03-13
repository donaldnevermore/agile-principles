using System;

namespace AgilePrinciples.Payroll.Domain {
    public interface PayrollSchedule {
        bool IsPayDate(DateTime payDate);
        DateTime GetPayPeriodStartDate(DateTime date);
    }
}
