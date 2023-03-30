namespace AgileSoftwareDevelopment.Visitor;

public interface Modem {
    void Dial(string pno);
    void Hangup();
    void Send(char c);
    char Recv();
    void Accept(ModemVisitor v);
}
