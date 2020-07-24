using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Methods
{
    public class ChangeHoldTransaction : ChangeMethodTransaction
    {
        public ChangeHoldTransaction(int id) : base(id)
        {
        }

        protected override PayrollMethod Method => new HoldMethod();
    }
}
