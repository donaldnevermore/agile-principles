namespace AgileSoftwareDevelopment.Payroll
{
    public class DirectMethod : PaymentMethod
    {
        public string Bank { get; }
        public string Account { get; }

        public DirectMethod(string bank, string account)
        {
            Bank = bank;
            Account = account;
        }

        public override void Pay(Paycheck paycheck)
        {
            // TODO:
        }
    }
}
