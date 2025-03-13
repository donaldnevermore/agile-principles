namespace AgilePrinciples.Payroll.Domain {
    public interface PayrollMethod {
        void Pay(Paycheck paycheck);
    }
}
