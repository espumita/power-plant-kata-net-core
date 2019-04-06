using System.Collections.Generic;
using PowerPlantKata.PowerConsumers;
using PowerPlantKata.PowerProducers;

namespace PowerPlantKata {
    public class PowerPlant : ElectricProducer<AreaElectricConsumer> {
        private List<AreaElectricConsumer> consumers;
        private readonly Electricity electricity = Electricity.CreateOneGigawatt();
        
        public PowerPlant() {
            consumers = new List<AreaElectricConsumer>();
        }

        public void SupplyElectricity() {
            var electricityForEachConsumer = electricity.GetDividedFor(consumers.Count);
            consumers.ForEach(consumer => consumer.Consume(electricityForEachConsumer));
        }

        public void AddElectricConsumer(AreaElectricConsumer consumer) {
            consumers.Add(consumer);
        }
    }
}