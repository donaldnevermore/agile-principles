﻿using Ch30.CommonTypes;

namespace Ch30.PayrollDomain;

public class Paycheck {
    private Date _endDate;
    private Date _startdate;

    public Paycheck(Date payPeriodStart, Date payPeriodEnd) {
        _endDate = payPeriodEnd;
        _startdate = payPeriodStart;
    }

    public decimal Deductions { get; set; }

    public decimal NetPay { get; set; }

    public decimal GrossPay { get; set; }

    public Date PayPeriodEndDate {
        get { return _endDate; }
    }

    public Date PayPeriodStartDate {
        get { return _startdate; }
    }

    public string GetField(string fieldName) {
        return "Hold";
    }
}
