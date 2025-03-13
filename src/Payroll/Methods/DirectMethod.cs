using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Methods {
    public class DirectMethod : PayrollMethod {
        public string Bank { get; }
        public string Account { get; }

        public DirectMethod(string bank, string account) {
            Bank = bank;
            Account = account;
        }

        public void Pay(Paycheck paycheck) {
            // TODO:
        }
    }
}
