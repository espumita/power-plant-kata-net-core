namespace PowerPlantKata {
    public interface ElectricProducer<T> where T: ElectricConsumer{
        void AddElectricConsumer(T consumer);
    }
}