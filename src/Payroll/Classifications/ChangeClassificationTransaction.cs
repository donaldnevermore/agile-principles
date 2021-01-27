using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Classifications {
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction {
        public ChangeClassificationTransaction(int id) : base(id) {
        }

        protected override void Change(Employee e) {
            e.Classification = Classification;
            e.Schedule = Schedule;
        }

        protected abstract PayrollClassification Classification { get; }
        protected abstract PayrollSchedule Schedule { get; }
    }
}
