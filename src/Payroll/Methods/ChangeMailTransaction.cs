using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Methods {
    public class ChangeMailTransaction : ChangeMethodTransaction {
        private readonly string address;

        public ChangeMailTransaction(int id, string address) : base(id) {
            this.address = address;
        }

        protected override PayrollMethod Method => new MailMethod(address);
    }
}
