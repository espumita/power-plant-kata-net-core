using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.PowerConsumers;

namespace PowerPlantKata.Tests {
    public class AreaShould {

        [Test]
        public void transmit_electricity_from_power_plant_to_cities() {
            var anArea = new Area();
            var anCityConsumer = Substitute.For<CityElectricConsumer>();
            var anotherCityConsumer = Substitute.For<CityElectricConsumer>();
            anArea.AddElectricConsumer(anCityConsumer);
            anArea.AddElectricConsumer(anotherCityConsumer);
            
            anArea.Consume(Electricity.CreateMegawatts(500));

            anCityConsumer.Received(1).Consume(Electricity.CreateMegawatts(250));
            anotherCityConsumer.Received(1).Consume(Electricity.CreateMegawatts(250));
        }
        
    }
}