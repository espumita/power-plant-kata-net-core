using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.PowerReceivers;
using PowerPlantKata.Reports;

namespace PowerPlantKata.Tests {
    
    public class PowerPlantShould {
        private Power OneGigawatt = Power.CreateOneGigawatt();

        [Test]
        public void supply_1_gigawatt_of_power_to_the_electric_network() {
            var aPowerPlant = new PowerPlant();
            var powerPlantConsumer = Substitute.For<Area>(new object[]{ null });
            aPowerPlant.AddPowerReceiver(powerPlantConsumer);

            aPowerPlant.SupplyPower();

            powerPlantConsumer.Received(1).ReceiveFrom(aPowerPlant, OneGigawatt);
        }
        
        [Test]
        public void supply_power_to_multiple_areas() {
            var aPowerPlant = new PowerPlant();
            var anAreaConsumer = Substitute.For<AreaPowerReceiver>();
            var anotherAreaConsumer = Substitute.For<AreaPowerReceiver>();
            aPowerPlant.AddPowerReceiver(anAreaConsumer);
            aPowerPlant.AddPowerReceiver(anotherAreaConsumer);

            aPowerPlant.SupplyPower();

            anAreaConsumer.Received(1).ReceiveFrom(aPowerPlant, Power.CreateMegawatts(500));
            anotherAreaConsumer.Received(1).ReceiveFrom(aPowerPlant, Power.CreateMegawatts(500));
        }
        
        
        [Test]
        public void get_monthly_report() {
            var aPowerPlant = new PowerPlant();
            var aBuildingReport = new BuildingConsumptionReport(Guid.NewGuid(), Power.CreateKilowatts(5));
            var someBuildingsReport = new List<BuildingConsumptionReport> {
                aBuildingReport, aBuildingReport
            };
            var someCitiesReport = new List<CityConsumptionReport> {
                new CityConsumptionReport(Guid.NewGuid(), someBuildingsReport),
                new CityConsumptionReport(Guid.NewGuid(), someBuildingsReport)
            };
            aPowerPlant.GetNotifiedOfElectricConsumeOff(new AreaConsumptionReport(Guid.NewGuid(), someCitiesReport));
            aPowerPlant.GetNotifiedOfElectricConsumeOff(new AreaConsumptionReport(Guid.NewGuid(), someCitiesReport));

            var monthlyReport = aPowerPlant.GetMonthlyReport();
            
            monthlyReport.TotalGeneratedPower.Should().BeEquivalentTo(OneGigawatt);
            monthlyReport.TotalConsumedPower().Should().BeEquivalentTo(Power.CreateKilowatts(40));
        }
    }
}