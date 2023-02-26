namespace AgileSoftwareDevelopment.Observer;

public class Subject {
    private readonly IList<Observer> itsObservers = new List<Observer>();

    public void NotifyObservers() {
        foreach (var observer in itsObservers) {
            observer.Update();
        }
    }

    public void RegisterObserver(Observer observer) {
        itsObservers.Add(observer);
    }
}
