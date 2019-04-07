using System;
using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.Reports;

namespace PowerPlantKata.Tests {
    public class BuildingShould {


        [Test]
        public void notify_cities_when_they_consume_electricity() {
            var aBuilding = new Building(id: Guid.NewGuid());
            var city = Substitute.For<City>();
            aBuilding.ReceiveFrom(city, Power.CreateKilowatts(4));

            aBuilding.NotifyConsumption();

            var consumptionReport = new BuildingConsumptionReport(aBuilding.Id, Power.CreateKilowatts(2));
            city.Received(1).GetNotifiedOfElectricConsumeOff(consumptionReport);
        }
        
    }
}