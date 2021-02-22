namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker {
    public class M4CoffeeMaker {
        public static void Start() {
            var api = new M4CoffeeMakerApi();
            var ui = new M4UserInterface(api);
            var hws = new M4HotWaterSource(api);
            var cv = new M4ContainmentVessel(api);

            ui.Init(hws, cv);
            hws.Init(ui, cv);
            cv.Init(ui, hws);

            for (; ; ) {
                ui.Poll();
                hws.Poll();
                cv.Poll();
            }
        }
    }
}
