using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Classifications;

public class SalesReceiptTransaction : Transaction {
    private readonly DateTime date;
    private readonly double saleAmount;
    private readonly int empId;

    public SalesReceiptTransaction(DateTime time, double saleAmount, int empId, PayrollDatabase database)
        : base(database) {
        this.date = time;
        this.saleAmount = saleAmount;
        this.empId = empId;
    }

    public override void Execute() {
        var e = database.GetEmployee(empId);
        if (e is null) {
            throw new ApplicationException(
                "No such employee.");
        }

        if (e.Classification is CommissionedClassification hc) {
            hc.AddSalesReceipt(new SalesReceipt(date, saleAmount));
        } else {
            throw new ApplicationException("Tried to add sales receipt to non-commissioned employee");
        }
    }
}
