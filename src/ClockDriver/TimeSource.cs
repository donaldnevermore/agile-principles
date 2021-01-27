namespace AgileSoftwareDevelopment.ClockDriver {
    public interface TimeSource {
        int Hours { get; }
        int Minutes { get; }
        int Seconds { get; }
    }
}
