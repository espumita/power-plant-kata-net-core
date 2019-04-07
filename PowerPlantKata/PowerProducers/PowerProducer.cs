using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata.PowerProducers {
    public interface PowerProducer<T> where T: PowerReceiver{
        void AddPowerReceiver(T powerReceiver);
        
        void GetNotifiedOfElectricConsumeOff(PowerReceiver powerReceiver,Power createKilowatts);
    }
}