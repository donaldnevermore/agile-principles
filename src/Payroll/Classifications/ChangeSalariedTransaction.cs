using AgileSoftwareDevelopment.Payroll.Domain;
using AgileSoftwareDevelopment.Payroll.Schedules;

namespace AgileSoftwareDevelopment.Payroll.Classifications {
    public class ChangeSalariedTransaction : ChangeClassificationTransaction {
        private readonly double salary;

        public ChangeSalariedTransaction(int id, double salary) : base(id) {
            this.salary = salary;
        }

        protected override PayrollClassification Classification => new SalariedClassification(salary);
        protected override PayrollSchedule Schedule => new MonthlySchedule();
    }
}
