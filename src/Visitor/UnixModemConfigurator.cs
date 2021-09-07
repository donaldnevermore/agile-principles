namespace AgileSoftwareDevelopment.Visitor {
    public class UnixModemConfigurator : ModemVisitor {
        public void Visit(HayesModem m) {
            m.ConfigurationString = "&s1=4&D=3";
        }

        public void Visit(ZoomModem m) {
            m.ConfigurationValue = 42;
        }

        public void Visit(ErnieModem m) {
            m.InternalPattern = "C is too slow";
        }
    }
}
