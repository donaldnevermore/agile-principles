namespace AgileSoftwareDevelopment.Payroll
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        public ChangeClassificationTransaction(int id) : base(id)
        {
        }

        protected override void Change(Employee e)
        {
            e.Classification = Classification;
            e.Schedule = Schedule;
        }

        protected abstract PaymentClassification Classification { get; }
        protected abstract PaymentSchedule Schedule { get; }
    }
}
