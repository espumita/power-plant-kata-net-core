using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata.Tests {
    public class CityShould {
        private Power SomeAreaPower = Power.CreateMegawatts(250);


        [Test]
        public void transmit_power_from_area_to_individual_buildings() {
            var anArea = Substitute.For<Area>();
            var aCity = new City();
            var aBuildingConsumer = Substitute.For<BuildingPowerReceiver>();
            var aNotherBuildingConsumer = Substitute.For<BuildingPowerReceiver>();
            aCity.AddPowerReceiver(aBuildingConsumer);
            aCity.AddPowerReceiver(aNotherBuildingConsumer);
            
            aCity.ReceiveFrom(anArea, SomeAreaPower);
            
            aBuildingConsumer.Received(1).ReceiveFrom(aCity,Power.CreateKilowatts(4));
            aNotherBuildingConsumer.Received(1).ReceiveFrom(aCity, Power.CreateKilowatts(4));            
        }
        
        
        [Test]
        public void notify_consume_of_all_buildings_to_area_when_electricity_is_consumed() {
            var anArea = Substitute.For<Area>();
            var aCity = new City();
            var aBuildingConsumer = Substitute.For<BuildingPowerReceiver>();
            var aNotherBuildingConsumer = Substitute.For<BuildingPowerReceiver>();
            aCity.AddPowerReceiver(aBuildingConsumer);
            aCity.AddPowerReceiver(aNotherBuildingConsumer);
            
            aCity.ReceiveFrom(anArea, SomeAreaPower);
            
            aBuildingConsumer.Received(1).ReceiveFrom(aCity,Power.CreateKilowatts(4));
            aNotherBuildingConsumer.Received(1).ReceiveFrom(aCity, Power.CreateKilowatts(4));            
        }
    }
}