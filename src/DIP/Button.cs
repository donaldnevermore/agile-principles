namespace AgilePrinciples.DIP;

public interface ButtonServer {
    void TurnOff();
    void TurnOn();
}

public class Lamp : ButtonServer {
    public void TurnOff() { }
    public void TurnOn() { }
}

public class Button {
    private readonly ButtonServer lamp;

    public void Poll() {
        if (true) {
            lamp.TurnOn();
        }
    }
}
