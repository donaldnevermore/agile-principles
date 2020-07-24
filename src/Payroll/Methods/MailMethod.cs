using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Methods
{
    public class MailMethod : PayrollMethod
    {
        public string Address { get; }

        public MailMethod(string address)
        {
            Address = address;
        }

        public void Pay(Paycheck paycheck)
        {
            // TODO:
        }
    }
}
