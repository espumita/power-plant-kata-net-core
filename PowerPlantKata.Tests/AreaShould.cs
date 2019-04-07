using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata.Tests {
    public class AreaShould {
        private Power SomePowerPlantPower = Power.CreateMegawatts(500);

        [Test]
        public void transmit_power_from_power_plant_to_cities() {
            var anArea = new Area();
            var anCityConsumer = Substitute.For<CityPowerReceiver>();
            var anotherCityConsumer = Substitute.For<CityPowerReceiver>();
            anArea.AddPowerReceiver(anCityConsumer);
            anArea.AddPowerReceiver(anotherCityConsumer);

            anArea.Receive(SomePowerPlantPower);

            anCityConsumer.Received(1).Receive(Power.CreateMegawatts(250));
            anotherCityConsumer.Received(1).Receive(Power.CreateMegawatts(250));
        }
        
    }
}