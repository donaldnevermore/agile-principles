namespace AgilePrinciples.Payroll.Domain;

public class Paycheck {
    private DateTime payDate;
    private readonly DateTime payPeriodStartDate;
    private double grossPay;
    private readonly Dictionary<string, string> fields = new();
    private double deductions;
    private double netPay;

    public Paycheck(DateTime payPeriodStartDate, DateTime payDate) {
        this.payPeriodStartDate = payPeriodStartDate;
        this.payDate = payDate;
    }

    public DateTime PayDate {
        get { return payDate; }
    }

    public double GrossPay {
        get { return grossPay; }
        set { grossPay = value; }
    }

    public void SetField(string fieldName, string value) {
        fields[fieldName] = value;
    }

    public string GetField(string fieldName) {
        return fields[fieldName];
    }

    public double Deductions {
        get { return deductions; }
        set { deductions = value; }
    }

    public double NetPay {
        get { return netPay; }
        set { netPay = value; }
    }

    public DateTime PayPeriodEndDate {
        get { return payDate; }
    }

    public DateTime PayPeriodStartDate {
        get { return payPeriodStartDate; }
    }
}
