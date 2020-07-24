using System;
using AgileSoftwareDevelopment.Payroll.Classifications;

namespace AgileSoftwareDevelopment.Payroll
{
    public class TimeCardTransaction : Transaction
    {
        private readonly DateTime date;
        private readonly double hours;
        private readonly int empId;

        public TimeCardTransaction(DateTime date, double hours, int empId)
        {
            this.date = date;
            this.hours = hours;
            this.empId = empId;
        }

        public void Execute()
        {
            var e = PayrollDatabase.GetEmployee(empId);

            if (e == null)
            {
                throw new InvalidOperationException("No such employee");
            }

            var hc = e.Classification as HourlyClassification;

            if (hc == null)
            {
                throw new InvalidOperationException("Tried to add time card to non-hourly employee");
            }

            hc.AddTimeCard(new TimeCard(date, hours));
        }
    }
}
