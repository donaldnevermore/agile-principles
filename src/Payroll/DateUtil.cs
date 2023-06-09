namespace AgileSoftwareDevelopment.Payroll;

public class DateUtil {
  /// <summary>
  /// Check if the date is in paycheck period.
  /// </summary>
  public static bool IsInPayPeriod(DateTime theDate, Paycheck paycheck) {
    var payPeriodEndDate = paycheck.PayPeriodEndDate;
    var payPeriodStartDate = paycheck.PayPeriodStartDate;
    return theDate >= payPeriodStartDate && theDate <= payPeriodEndDate;
  }

  public static bool IsLastDayOfMonth(DateTime date) {
    var m1 = date.Month;
    var m2 = date.AddDays(1).Month;
    return m1 != m2;
  }
}
