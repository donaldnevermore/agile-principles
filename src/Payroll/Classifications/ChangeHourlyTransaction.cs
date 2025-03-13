using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll.Classifications {
    public class ChangeHourlyTransaction : ChangeClassificationTransaction {
        private readonly double hourlyRate;

        public ChangeHourlyTransaction(int id, double hourlyRate) : base(id) {
            this.hourlyRate = hourlyRate;
        }

        protected override PayrollClassification Classification => new HourlyClassification(hourlyRate);
        protected override PayrollSchedule Schedule => new WeeklySchedule();
    }
}
