namespace AgileSoftwareDevelopment.Payroll
{
    public abstract class PaymentMethod
    {
        public abstract void Pay(Paycheck paycheck);
    }
}
