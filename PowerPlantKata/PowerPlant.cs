using System.Collections.Generic;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;
using PowerPlantKata.Reports;

namespace PowerPlantKata {
    public class PowerPlant : PowerProducer<AreaPowerReceiver> {
        private List<AreaPowerReceiver> powerReceivers;
        private readonly Power power = Power.CreateOneGigawatt();
        
        public PowerPlant() {
            powerReceivers = new List<AreaPowerReceiver>();
        }

        public void AddPowerReceiver(AreaPowerReceiver powerReceiver) {
            powerReceivers.Add(powerReceiver);
        }

        public void SupplyPower() {
            var powerForEachReceiver = power.GetDividedFor(powerReceivers.Count);
            powerReceivers.ForEach(consumer => consumer.ReceiveFrom(this, powerForEachReceiver));
        }


        public virtual void GetNotifiedOfElectricConsumeOff(AreaConsumptionReport areaConsumptionReport) {
            throw new System.NotImplementedException();
        }
    }
}