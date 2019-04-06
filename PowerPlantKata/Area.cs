using System.Collections.Generic;
using PowerPlantKata.PowerConsumers;
using PowerPlantKata.PowerProducers;

namespace PowerPlantKata {
    
    
    
    public class Area : AreaElectricConsumer, ElectricProducer<CityElectricConsumer> {
        private List<CityElectricConsumer> consumers;
        
        
        public Area() {
            consumers = new List<CityElectricConsumer>();
        }

        public void Consume(Electricity electricity) {
            var electricityForEachConsumer = electricity.GetDividedFor(consumers.Count);
            consumers.ForEach(consumer => consumer.Consume(electricityForEachConsumer));
        }


        public void AddElectricConsumer(CityElectricConsumer consumer) {
            consumers.Add(consumer);
        }
    }
}