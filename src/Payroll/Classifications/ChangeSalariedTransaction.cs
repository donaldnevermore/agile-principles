using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll.Classifications {
    public class ChangeSalariedTransaction : ChangeClassificationTransaction {
        private readonly double salary;

        public ChangeSalariedTransaction(int id, double salary) : base(id) {
            this.salary = salary;
        }

        protected override PayrollClassification Classification => new SalariedClassification(salary);
        protected override PayrollSchedule Schedule => new MonthlySchedule();
    }
}
