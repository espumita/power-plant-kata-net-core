using NSubstitute;
using NUnit.Framework;

namespace PowerPlantKata.Tests {
    
    public class PowerPlantShould {
        private Electricity OneGigawatt = Electricity.CreateOneGigawatt();

        [Test]
        public void supply_1_gigawatt_to_the_electric_network() {
            var aPowerPlant = new PowerPlant();
            var powerPlantConsumer = Substitute.For<AreaElectricConsumer>();
            aPowerPlant.AddElectricConsumer(powerPlantConsumer);

            aPowerPlant.SupplyElectricity();

            powerPlantConsumer.Received(1).Consume(OneGigawatt);
        }
        
        
        [Test]
        public void supply_electricity_to_multiple_areas() {
            var aPowerPlant = new PowerPlant();
            var anAreaConsumer = Substitute.For<AreaElectricConsumer>();
            var anotherAreaConsumer = Substitute.For<AreaElectricConsumer>();
            aPowerPlant.AddElectricConsumer(anAreaConsumer);
            aPowerPlant.AddElectricConsumer(anotherAreaConsumer);

            aPowerPlant.SupplyElectricity();

            anAreaConsumer.Received(1).Consume(Electricity.GetMegawatts(500));
            anotherAreaConsumer.Received(1).Consume(Electricity.GetMegawatts(500));
        }
    }
}