using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Methods {
    public class ChangeHoldTransaction : ChangeMethodTransaction {
        public ChangeHoldTransaction(int id) : base(id) {
        }

        protected override PayrollMethod Method => new HoldMethod();
    }
}
