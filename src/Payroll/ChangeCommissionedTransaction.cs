namespace AgileSoftwareDevelopment.Payroll
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly double salary;
        private readonly double commissionRate;

        public ChangeCommissionedTransaction(int id, double salary, double commissionRate) : base(id)
        {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }

        protected override PaymentClassification Classification =>
            new CommissionedClassification(salary, commissionRate);

        protected override PaymentSchedule Schedule => new BiweeklySchedule();
    }
}
