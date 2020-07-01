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
    }
}
