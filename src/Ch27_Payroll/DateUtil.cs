namespace AgilePrinciples.Payroll;

public static class DateUtil {
    /// <summary>
    /// Check if the date is in paycheck period.
    /// </summary>
    public static bool IsInPayPeriod(
        DateTime theDate, DateTime startDate, DateTime endDate) {
        return (theDate >= startDate) && (theDate <= endDate);
    }
}
