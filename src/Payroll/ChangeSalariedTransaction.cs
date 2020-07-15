namespace AgileSoftwareDevelopment.Payroll
{
    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {
        private readonly double salary;

        public ChangeSalariedTransaction(int id, double salary) : base(id)
        {
            this.salary = salary;
        }

        protected override PaymentClassification Classification => new SalariedClassification(salary);
        protected override PaymentSchedule Schedule => new MonthlySchedule();
    }
}
