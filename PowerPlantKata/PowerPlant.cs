using System.Collections.Generic;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata {
    public class PowerPlant : PowerProducer<AreaPowerReceiver> {
        private List<AreaPowerReceiver> powerReceivers;
        private readonly Power Power = Power.CreateOneGigawatt();
        
        public PowerPlant() {
            powerReceivers = new List<AreaPowerReceiver>();
        }

        public void SupplyPower() {
            var powerForEachReceiver = Power.GetDividedFor(powerReceivers.Count);
            powerReceivers.ForEach(consumer => consumer.Receive(powerForEachReceiver));
        }

        public void AddPowerReceiver(AreaPowerReceiver powerReceiver) {
            powerReceivers.Add(powerReceiver);
        }
    }
}