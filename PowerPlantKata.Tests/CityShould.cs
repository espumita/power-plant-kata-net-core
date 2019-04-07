using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata.Tests {
    public class CityShould {
        private Power SomeAreaPower = Power.CreateMegawatts(250);


        [Test]
        public void transmit_power_from_area_to_individual_buildings() {
            var aCity = new City();
            var aBuildingConsumer = Substitute.For<BuildingPowerReceiver>();
            var aNotherBuildingConsumer = Substitute.For<BuildingPowerReceiver>();
            aCity.AddPowerReceiver(aBuildingConsumer);
            aCity.AddPowerReceiver(aNotherBuildingConsumer);
            
            aCity.Receive(SomeAreaPower);
            
            aBuildingConsumer.Received(1).Receive(Power.CreateKilowatts(4));
            aNotherBuildingConsumer.Received(1).Receive(Power.CreateKilowatts(4));            
        }
    }
}