﻿using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Schedules;

public class WeeklySchedule : PaymentSchedule {
    public bool IsPayDate(DateTime payDate) {
        return payDate.DayOfWeek == DayOfWeek.Friday;
    }

    public DateTime GetPayPeriodStartDate(DateTime date) {
        return date.AddDays(-6);
    }

    public override string ToString() {
        return "weekly";
    }
}
