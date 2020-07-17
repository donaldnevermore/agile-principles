namespace AgileSoftwareDevelopment.Payroll
{
    public class ChangeHoldTransaction : ChangeMethodTransaction
    {
        public ChangeHoldTransaction(int id) : base(id)
        {
        }

        protected override PaymentMethod Method => new HoldMethod();
    }
}
