namespace AgileSoftwareDevelopment.ClockDriver
{
    public class MockTimeSink : Observer
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        private TimeSource itsSource;

        public MockTimeSink(TimeSource source)
        {
            itsSource = source;
        }

        public void Update()
        {
            Hours = itsSource.Hours;
            Minutes = itsSource.Minutes;
            Seconds = itsSource.Seconds;
        }
    }
}
