namespace AgileSoftwareDevelopment.Visitor {
    public class ZoomModem : Modem {
        public void Dial(string pno) {
        }

        public void Hangup() {
        }

        public void Send(char c) {
        }

        public char Recv() {
            return (char)0;
        }

        public void Accept(ModemVisitor v) {
            v.Visit(this);
        }

        public int ConfigurationValue { get; set; } = 0;
    }
}
