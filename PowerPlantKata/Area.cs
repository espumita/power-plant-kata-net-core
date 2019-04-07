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

        public virtual void ReceiveFrom<T>(PowerProducer<T> powerSource, Power power) where T : PowerReceiver {
            var electricityForEachConsumer = power.GetDividedFor(powerReceivers.Count);
            powerReceivers.ForEach(consumer => consumer.ReceiveFrom(this, electricityForEachConsumer));
        }

    }
}