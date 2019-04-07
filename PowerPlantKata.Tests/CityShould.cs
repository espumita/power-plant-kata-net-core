using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.PowerConsumers;

namespace PowerPlantKata.Tests {
    public class CityShould {
        private Electricity someAreaElectricity = Electricity.CreateMegawatts(250);


        [Test]
        public void transmit_electricity_from_area_to_individual_buildings() {
            var aCity = new City();
            var aBuildingConsumer = Substitute.For<BuildingElectricConsumer>();
            var aNotherBuildingConsumer = Substitute.For<BuildingElectricConsumer>();
            aCity.AddElectricConsumer(aBuildingConsumer);
            aCity.AddElectricConsumer(aNotherBuildingConsumer);
            
            aCity.Consume(someAreaElectricity);
            
            aBuildingConsumer.Received(1).Consume(Electricity.CreateKilowatts(4));
            aNotherBuildingConsumer.Received(1).Consume(Electricity.CreateKilowatts(4));            
        }
    }
}