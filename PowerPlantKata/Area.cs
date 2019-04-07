using System.Collections.Generic;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata {
    
    public class Area : AreaPowerReceiver, PowerProducer<CityPowerReceiver> {
        private List<CityPowerReceiver> powerReceivers;
        
        public Area() {
            powerReceivers = new List<CityPowerReceiver>();
        }

        public void AddPowerReceiver(CityPowerReceiver powerReceiver) {
            powerReceivers.Add(powerReceiver);
        }

        public void Receive(Power power) {
            var electricityForEachConsumer = power.GetDividedFor(powerReceivers.Count);
            powerReceivers.ForEach(consumer => consumer.Receive(electricityForEachConsumer));
        }
    }
}