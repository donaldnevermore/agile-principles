namespace AgileSoftwareDevelopment.Payroll
{
    public class MailMethod : PaymentMethod
    {
        public string Address { get; }

        public MailMethod(string address)
        {
            Address = address;
        }
    }
}
