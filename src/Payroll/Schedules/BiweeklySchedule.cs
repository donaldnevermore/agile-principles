using System;
using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Schedules {
    public class BiweeklySchedule : PayrollSchedule {
        private DateTime? previousPayDate = null;

        public bool IsPayDate(DateTime payDate) {
            if (payDate.DayOfWeek != DayOfWeek.Friday) {
                return false;
            }

            // First pay or every other week
            if (previousPayDate is null || (payDate - previousPayDate == TimeSpan.FromDays(14))) {
                previousPayDate = payDate;
                return true;
            }

            return false;
        }

        public DateTime GetPayPeriodStartDate(DateTime date) {
            // Avoid duplicate pay.
            return date.AddDays(-13);
        }
    }
}
