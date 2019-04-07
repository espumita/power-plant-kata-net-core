using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.PowerReceivers;
using PowerPlantKata.Reports;

namespace PowerPlantKata.Tests {
    public class AreaShould {
        private Power SomePowerPlantPower = Power.CreateMegawatts(500);

        [Test]
        public void transmit_power_from_power_plant_to_cities() {
            var aPowerPlant = Substitute.For<PowerPlant>();
            var anArea = new Area(id: Guid.NewGuid());
            var anCityConsumer = Substitute.For<CityPowerReceiver>();
            var anotherCityConsumer = Substitute.For<CityPowerReceiver>();
            anArea.AddPowerReceiver(anCityConsumer);
            anArea.AddPowerReceiver(anotherCityConsumer);

            anArea.ReceiveFrom(aPowerPlant, SomePowerPlantPower);

            anCityConsumer.Received(1).ReceiveFrom(anArea, Power.CreateMegawatts(250));
            anotherCityConsumer.Received(1).ReceiveFrom(anArea ,Power.CreateMegawatts(250));
        }
        
        [Test]
        public void notify_consume_of_all_cities_to_power_plant_when_electricity_is_consumed() {
            var aPowerPlant = Substitute.For<PowerPlant>();
            var anArea = new Area(id: Guid.NewGuid());
            var anCityConsumer = Substitute.For<CityPowerReceiver>();
            anArea.AddPowerReceiver(anCityConsumer);
            anArea.ReceiveFrom(aPowerPlant, SomePowerPlantPower);
            var aCityConsumptionReport = new CityConsumptionReport(Guid.NewGuid(), new List<BuildingConsumptionReport>());
            var anotherCityConsumptionReport = new CityConsumptionReport(Guid.NewGuid(), new List<BuildingConsumptionReport>());
            anArea.GetNotifiedOfElectricConsumeOff(aCityConsumptionReport);
            anArea.GetNotifiedOfElectricConsumeOff(anotherCityConsumptionReport);
            
            anArea.NotifyConsumption();
            
            var expectedConsumptionReport = new AreaConsumptionReport(anArea.Id, new List<CityConsumptionReport> {
                aCityConsumptionReport, anotherCityConsumptionReport
            });
            aPowerPlant.Received(1).GetNotifiedOfElectricConsumeOff(expectedConsumptionReport);
        }
        
    }
}