using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Classifications;

public class CommissionedClassification : PaymentClassification {
    public double BaseRate { get; }
    public double CommissionRate { get; }

    private readonly Dictionary<DateTime, SalesReceipt> salesReceipts = new();

    public CommissionedClassification(double baseRate, double commissionRate) {
        BaseRate = baseRate;
        CommissionRate = commissionRate;
    }

    public void AddSalesReceipt(SalesReceipt salesReceipt) {
        salesReceipts.Add(salesReceipt.Date, salesReceipt);
    }

    public SalesReceipt GetSalesReceipt(DateTime date) {
        return salesReceipts[date];
    }

    public override double CalculatePay(Paycheck paycheck) {
        double salesTotal = 0;
        foreach (SalesReceipt receipt in salesReceipts.Values) {
            if (DateUtil.IsInPayPeriod(receipt.Date,
                    paycheck.PayPeriodStartDate,
                    paycheck.PayPeriodEndDate))
                salesTotal += receipt.SaleAmount;
        }

        return BaseRate + (salesTotal * CommissionRate * 0.01);
    }

    public override string ToString() {
        return String.Format("${0} + {1}% sales commission", BaseRate, CommissionRate);
    }
}
