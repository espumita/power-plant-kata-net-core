using System;
using System.Collections.Generic;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;
using PowerPlantKata.Reports;

namespace PowerPlantKata {
    public class City : CityPowerReceiver, PowerProducer<BuildingPowerReceiver> {
        public Guid Id { get; }
        private Area powerSource;
        private readonly List<BuildingPowerReceiver> powerReceivers;
        private readonly List<BuildingConsumptionReport> consumptionReports;
        
        
        
        
        public City(Guid id) {
            Id = id;
            powerReceivers = new List<BuildingPowerReceiver>();
            consumptionReports = new List<BuildingConsumptionReport>();
        }


        public void AddPowerReceiver(BuildingPowerReceiver powerReceiver) {
            powerReceivers.Add(powerReceiver);
        }

        public virtual void ReceiveFrom<T>(PowerProducer<T> powerSource, Power power) where T : PowerReceiver {
            this.powerSource = (Area) powerSource;
            var averageBuildingElectricityNeeded = Power.CreateKilowatts(4);
            powerReceivers.ForEach(consumers => consumers.ReceiveFrom(this, averageBuildingElectricityNeeded));
        }

        public virtual void GetNotifiedOfElectricConsumeOff(BuildingConsumptionReport consumptionReport) {
            consumptionReports.Add(consumptionReport);
        }

        public void NotifyConsumption() {
            powerSource.GetNotifiedOfElectricConsumeOff(new CityConsumptionReport(Id, consumptionReports));
        }
    }
}