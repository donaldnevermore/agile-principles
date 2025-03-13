namespace AgilePrinciples.Observer {
    public class MockTimeSource : Subject, TimeSource {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public void SetTime(int hours, int mins, int secs) {
            Hours = hours;
            Minutes = mins;
            Seconds = secs;
            NotifyObservers();
        }
    }
}
