using NSubstitute;
using NUnit.Framework;

namespace PowerPlantKata.Tests {
    
    public class PowerPlantShould {
        private Electricity OneGigawatt = Electricity.CreateOneGigawatt();

        [Test]
        public void supply_1_gigawatt_to_the_electric_network() {
            var aPowerPlant = new PowerPlant();
            var powerPlantConsumer = Substitute.For<ElectricConsumer>();
            aPowerPlant.AddElectricConsumer(powerPlantConsumer);

            aPowerPlant.SupplyElectricity();

            powerPlantConsumer.Received(1).Consume(OneGigawatt);
        }
    }
}