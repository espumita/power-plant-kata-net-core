using System.Collections.Generic;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata {
    public class City : CityPowerReceiver, PowerProducer<BuildingPowerReceiver> {
        private readonly List<BuildingPowerReceiver> powerReceivers;
        public City() {
            powerReceivers = new List<BuildingPowerReceiver>();
        }


        public void Receive(Power power) {
            var averageBuildingElectricityNeeded = Power.CreateKilowatts(4);
            powerReceivers.ForEach(consumers => consumers.Receive(averageBuildingElectricityNeeded));
        }

        public void AddPowerReceiver(BuildingPowerReceiver powerReceiver) {
            powerReceivers.Add(powerReceiver);
        }
    }
}