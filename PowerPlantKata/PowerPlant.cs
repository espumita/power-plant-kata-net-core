using System.Collections.Generic;
using System.Linq;

namespace PowerPlantKata {
    public class PowerPlant : ElectricProducer {
        private List<ElectricConsumer> consumers;
        private readonly Electricity electricity = Electricity.CreateOneGigawatt();
        
        public PowerPlant() {
            consumers = new List<ElectricConsumer>();
        }


        public void SupplyElectricity() {
            consumers.First().Consume(electricity);
        }

        public void AddElectricConsumer(ElectricConsumer consumer) {
            consumers.Add(consumer);
        }
    }
}