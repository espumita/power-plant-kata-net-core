using NSubstitute;
using NUnit.Framework;

namespace PowerPlantKata.Tests {
    public class BuildingShould {


        [Test]
        public void notify_cities_when_they_consume_electricity() {
            var aBuilding = new Building();
            var city = Substitute.For<City>();
            aBuilding.ReceiveFrom(city, Power.CreateKilowatts(4));

            aBuilding.NotifyConsumition();
            
            city.Received(1).GetNotifiedOfElectricConsumeOff(aBuilding, Power.CreateKilowatts(2));
        }
        
    }
}