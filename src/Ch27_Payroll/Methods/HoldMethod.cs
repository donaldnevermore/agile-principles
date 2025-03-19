using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Methods {
    public class HoldMethod : PaymentMethod
    {
        public void Pay(Paycheck paycheck)
        {
            paycheck.SetField("Disposition", "Hold");
        }

        public override string ToString()
        {
            return "hold";
        }
    }
}
