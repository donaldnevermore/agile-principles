using System;
using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Schedules {
    public class WeeklySchedule : PayrollSchedule {
        public bool IsPayDate(DateTime payDate) {
            return payDate.DayOfWeek == DayOfWeek.Friday;
        }

        public DateTime GetPayPeriodStartDate(DateTime date) {
            return date.AddDays(-5);
        }
    }
}
