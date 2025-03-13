using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll.Classifications {
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction {
        private readonly double salary;
        private readonly double commissionRate;

        public ChangeCommissionedTransaction(int id, double salary, double commissionRate) : base(id) {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }

        protected override PayrollClassification Classification =>
            new CommissionedClassification(salary, commissionRate);

        protected override PayrollSchedule Schedule => new BiweeklySchedule();
    }
}
