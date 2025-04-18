﻿using Ch30.CommonTypes;

namespace Ch30.PayrollDomain;

public abstract class PaymentClassification {
    public abstract decimal CalculatePay(Paycheck paycheck);

    public bool IsInPayPeriod(Date theDate, Paycheck payCheck) {
        return Date.IsBetween(theDate, payCheck.PayPeriodStartDate, payCheck.PayPeriodEndDate);
    }

    public virtual void AddSalesReceipt(decimal _amount, Date _forDate) {
        throw new Exception("Employee not commissioned");
    }

    public virtual void AddTimeCard(Date forDate, decimal hours) {
        throw new Exception("Tried to add timecard to non-hourly employee");
    }
}
