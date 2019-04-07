using System.Collections.Generic;
using PowerPlantKata.PowerConsumers;
using PowerPlantKata.PowerProducers;

namespace PowerPlantKata {
    public class City : CityElectricConsumer, ElectricProducer<BuildingElectricConsumer> {
        private readonly List<BuildingElectricConsumer> consumers;
        public City() {
            consumers = new List<BuildingElectricConsumer>();
        }


        public void Consume(Electricity electricity) {
            var averageBuildingElectricityNeeded = Electricity.CreateKilowatts(4);
            consumers.ForEach(consumers => consumers.Consume(averageBuildingElectricityNeeded));
        }

        public void AddElectricConsumer(BuildingElectricConsumer consumer) {
            consumers.Add(consumer);
        }
    }
}