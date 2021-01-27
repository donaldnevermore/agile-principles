using System;

namespace AgileSoftwareDevelopment.Payroll.Classifications {
    public class TimeCard {
        public double Hours { get; }
        public DateTime Date { get; }

        public TimeCard(DateTime date, double hours) {
            Date = date;
            Hours = hours;
        }
    }
}
