using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll.Classifications {
    public class ChangeHourlyTransaction : ChangeClassificationTransaction {
        private readonly double hourlyRate;

        public ChangeHourlyTransaction(int id, double hourlyRate, PayrollDatabase database)
            : base(id, database)
        {
            this.hourlyRate = hourlyRate;
        }

        protected override PaymentClassification Classification
        {
            get { return new HourlyClassification(hourlyRate); }
        }

        protected override PaymentSchedule Schedule
        {
            get { return new WeeklySchedule(); }
        }
    }
}
