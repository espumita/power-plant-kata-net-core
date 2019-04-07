using System.Collections.Generic;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;
using PowerPlantKata.Reports;

namespace PowerPlantKata {
    public class City : CityPowerReceiver, PowerProducer<BuildingPowerReceiver> {
        private readonly List<BuildingPowerReceiver> powerReceivers;
        public City() {
            powerReceivers = new List<BuildingPowerReceiver>();
        }


        public void AddPowerReceiver(BuildingPowerReceiver powerReceiver) {
            powerReceivers.Add(powerReceiver);
        }

        public virtual void ReceiveFrom<T>(PowerProducer<T> powerSource, Power power) where T : PowerReceiver {
            var averageBuildingElectricityNeeded = Power.CreateKilowatts(4);
            powerReceivers.ForEach(consumers => consumers.ReceiveFrom(this, averageBuildingElectricityNeeded));
        }

        public virtual void GetNotifiedOfElectricConsumeOff(BuildingConsumptionReport consumptionReport) {
            throw new System.NotImplementedException();
        }
    }
}