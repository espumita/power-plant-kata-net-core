using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata {
    public class Building : BuildingPowerReceiver {

        private Power networkPower;
        private PowerProducer<PowerReceiver> powerSource;
        
        public virtual void ReceiveFrom<T>(PowerProducer<T> powerSource, Power power) where T : PowerReceiver {
            networkPower = power;
            this.powerSource = (PowerProducer<PowerReceiver>) powerSource;
        }
        
        public void NotifyConsumition() {
            powerSource.GetNotifiedOfElectricConsumeOff(this, Power.CreateKilowatts(2));
        }


    }
}