using System;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;
using PowerPlantKata.Reports;

namespace PowerPlantKata {
    public class Building : BuildingPowerReceiver {
        public Guid Id { get; }
        private Power networkPower;
        private City powerSource;

        public Building(Guid id) {
            this.Id = id;
        }

        public virtual void ReceiveFrom<T>(PowerProducer<T> powerSource, Power power) where T : PowerReceiver {
            networkPower = power;
            this.powerSource = (City) powerSource;
        }
        
        public void NotifyConsumption() {
            var report = GetReport();
            powerSource.GetNotifiedOfElectricConsumeOff(report);
        }

        private BuildingConsumptionReport GetReport() {
            return new BuildingConsumptionReport(Id, Power.CreateKilowatts(2));
        }
    }
}