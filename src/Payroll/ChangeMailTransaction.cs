namespace AgileSoftwareDevelopment.Payroll
{
    public class ChangeMailTransaction : ChangeMethodTransaction
    {
        private readonly string address;

        public ChangeMailTransaction(int id, string address) : base(id)
        {
            this.address = address;
        }

        protected override PaymentMethod Method => new MailMethod(address);
    }
}
