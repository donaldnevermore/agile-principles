using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll.Classifications {
    public class ChangeCommissionedTransaction
        : ChangeClassificationTransaction
    {
        private readonly double baseSalary;
        private readonly double commissionRate;

        public ChangeCommissionedTransaction(int id, double baseSalary, double commissionRate, PayrollDatabase database)
            : base(id, database)
        {
            this.baseSalary = baseSalary;
            this.commissionRate = commissionRate;
        }

        protected override PaymentClassification Classification
        {
            get { return new CommissionedClassification(baseSalary, commissionRate); }
        }

        protected override PaymentSchedule Schedule
        {
            get { return new BiweeklySchedule(); }
        }
    }
}
