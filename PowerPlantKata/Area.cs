using System;
using System.Collections.Generic;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;
using PowerPlantKata.Reports;

namespace PowerPlantKata {
    
    public class Area : AreaPowerReceiver, PowerProducer<CityPowerReceiver> {
        public Guid Id { get; }
        private List<CityPowerReceiver> powerReceivers;
        private List<CityConsumptionReport> consumptionReports;
        private PowerPlant powerSource;
        
        public Area(Guid id) {
            Id = id;
            powerReceivers = new List<CityPowerReceiver>();
            consumptionReports = new List<CityConsumptionReport>();
        }

        public void AddPowerReceiver(CityPowerReceiver powerReceiver) {
            powerReceivers.Add(powerReceiver);
        }

        public virtual void ReceiveFrom<T>(PowerProducer<T> powerSource, Power power) where T : PowerReceiver {
            this.powerSource = (PowerPlant) powerSource;
            var electricityForEachConsumer = power.GetDividedFor(powerReceivers.Count);
            powerReceivers.ForEach(consumer => consumer.ReceiveFrom(this, electricityForEachConsumer));
        }

        public virtual void GetNotifiedOfElectricConsumeOff(CityConsumptionReport consumptionReport) {
            consumptionReports.Add(consumptionReport);
        }

        public void NotifyConsumption() {
            powerSource.GetNotifiedOfElectricConsumeOff(new AreaConsumptionReport(Id, consumptionReports));
        }
    }
}