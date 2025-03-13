﻿using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Classifications;

public class HourlyClassification : PayrollClassification {
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

    public double CalculatePay(Paycheck paycheck) {
        var totalPay = 0.0;
        foreach (var timeCard in timeCards.Values) {
            if (IsInPayPeriod(timeCard, paycheck)) {
                totalPay += CalculatePayForTimeCard(timeCard);
            }
        }

        return totalPay;
    }

    private static bool IsInPayPeriod(TimeCard card, Paycheck paycheck) {
        return DateUtil.IsInPayPeriod(card.Date, paycheck);
    }

    private double CalculatePayForTimeCard(TimeCard card) {
        var overtimeHours = Math.Max(0.0, card.Hours - 8);
        var normalHours = card.Hours - overtimeHours;
        return HourlyRate * normalHours + HourlyRate * 1.5 * overtimeHours;
    }
}
