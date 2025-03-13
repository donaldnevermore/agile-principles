using Ch30.PayrollDomain;

namespace Ch30.PayrollImplementation;

public class MailMethod : PaymentMethod {
    private string _address;

    public string Address {
        get { return _address; }
    }

    public MailMethod(string address) {
        this._address = address;
    }

    public void Pay(Paycheck paycheck) {
    }
}
