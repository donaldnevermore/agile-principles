namespace AgilePrinciples.DIP;

public class Regulator {
    public void Regulate(Thermometer t, Heater h, double minTemp, double maxTemp) {
        for (; ; ) {
            while (t.Read() > minTemp) {
                Wait(1);
            }

            // Heat up
            h.Engage();

            while (t.Read() < maxTemp) {
                Wait(1);
            }

            // Cool down
            h.Disengage();
        }
    }

    /// <summary>
    /// A mock method.
    /// </summary>
    private void Wait(int seconds) { }
}
