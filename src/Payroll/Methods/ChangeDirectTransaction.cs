using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Methods {
    public class ChangeDirectTransaction : ChangeMethodTransaction {
        private readonly string bank;
        private readonly string account;

        public ChangeDirectTransaction(int id, string bank, string account) : base(id) {
            this.bank = bank;
            this.account = account;
        }

        protected override PayrollMethod Method => new DirectMethod(bank, account);
    }
}
