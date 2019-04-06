using PowerPlantKata.PowerConsumers;

namespace PowerPlantKata.PowerProducers {
    public interface ElectricProducer<T> where T: ElectricConsumer{
        void AddElectricConsumer(T consumer);
    }
}