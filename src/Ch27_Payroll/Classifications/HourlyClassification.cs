using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Classifications;

public class HourlyClassification : PaymentClassification {
    public double HourlyRate { get; }
    private readonly Dictionary<DateTime, TimeCard> timeCards = new();

    public HourlyClassification(double hourlyRate) {
        HourlyRate = hourlyRate;
    }

    public void AddTimeCard(TimeCard timeCard) {
        timeCards.Add(timeCard.Date, timeCard);
    }

    public TimeCard GetTimeCard(DateTime date) {
        return timeCards[date];
    }

    public override double CalculatePay(Paycheck paycheck) {
        double totalPay = 0.0;
        foreach (TimeCard timeCard in timeCards.Values) {
            if (DateUtil.IsInPayPeriod(timeCard.Date,
                    paycheck.PayPeriodStartDate,
                    paycheck.PayPeriodEndDate))
                totalPay += CalculatePayForTimeCard(timeCard);
        }

        return totalPay;
    }


    private double CalculatePayForTimeCard(TimeCard card) {
        double overtimeHours = Math.Max(0.0, card.Hours - 8);
        double normalHours = card.Hours - overtimeHours;
        return HourlyRate * normalHours +
               HourlyRate * 1.5 * overtimeHours;
    }

    public override string ToString() {
        return String.Format("${0}/hr", HourlyRate);
    }
}
