namespace AgileSoftwareDevelopment.Regulator
{
    public class Regulator
    {
        public void Regulate(Thermometer t, Heater h, double minTemp, double maxTemp)
        {
            while (true)
            {
                while (t.Read() > minTemp)
                {
                    Wait(1);
                }

                // Heat up.
                h.Engage();
                while (t.Read() < maxTemp)
                {
                    Wait(1);
                }

                // Cold down.
                h.Disengage();
            }
        }

        /// <summary>
        /// A stub.
        /// </summary>
        private void Wait(int seconds)
        {
        }
    }
}