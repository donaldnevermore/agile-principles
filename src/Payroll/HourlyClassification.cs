using System;
using System.Collections.Generic;

namespace AgileSoftwareDevelopment.Payroll
{
    public class HourlyClassification : PaymentClassification
    {
        public double HourlyRate { get; }
        private readonly Dictionary<DateTime, TimeCard> timeCards = new Dictionary<DateTime, TimeCard>();

        public HourlyClassification(double hourlyRate)
        {
            HourlyRate = hourlyRate;
        }

        public void AddTimeCard(TimeCard timeCard)
        {
            timeCards.Add(timeCard.Date, timeCard);
        }

        public TimeCard GetTimeCard(DateTime date)
        {
            return timeCards[date];
        }

        public override double CalculatePay(Paycheck paycheck)
        {
            var totalPay = 0.0;
            foreach (var timeCard in timeCards.Values)
            {
                if (IsInPayPeriod(timeCard, paycheck.PayDate))
                {
                    totalPay += CalculatePayForTimeCard(timeCard);
                }
            }

            return totalPay;
        }

        private bool IsInPayPeriod(TimeCard card, DateTime payPeriod)
        {
            var payPeriodEndDate = payPeriod;
            // Workdays only.
            var payPeriodStartDate = payPeriod.AddDays(-5);
            return card.Date <= payPeriodEndDate && card.Date >= payPeriodStartDate;
        }

        private double CalculatePayForTimeCard(TimeCard card)
        {
            var overtimeHours = Math.Max(0.0, card.Hours - 8);
            var normalHours = card.Hours - overtimeHours;
            return HourlyRate * normalHours + HourlyRate * 1.5 * overtimeHours;
        }
    }
}
