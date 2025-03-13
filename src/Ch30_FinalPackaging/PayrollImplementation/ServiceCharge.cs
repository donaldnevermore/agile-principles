using Ch30.CommonTypes;

namespace Ch30.PayrollImplementation;

public class ServiceCharge {
    private Date _forDate;

    public Date Date {
        get { return _forDate; }
    }

    private decimal _charge;

    public decimal Amount {
        get { return _charge; }
    }

    public ServiceCharge(Date forDate, decimal charge) {
        _forDate = forDate;
        _charge = charge;
    }
}
