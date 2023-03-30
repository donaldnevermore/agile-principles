namespace AgileSoftwareDevelopment.Visitor;

public interface ModemVisitor {
    void Visit(HayesModem m);
    void Visit(ZoomModem m);
    void Visit(ErnieModem m);
}
