using PowerPlantKata.PowerProducers;

namespace PowerPlantKata.PowerReceivers {
    public interface PowerReceiver {
        void ReceiveFrom<T>(PowerProducer<T> powerSource, Power power) where T : PowerReceiver;
    }
}