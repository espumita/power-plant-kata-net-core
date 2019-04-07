using NSubstitute;
using NUnit.Framework;
using PowerPlantKata.PowerReceivers;

namespace PowerPlantKata.Tests {
    
    public class PowerPlantShould {
        private Power OneGigawatt = Power.CreateOneGigawatt();

        [Test]
        public void supply_1_gigawatt_of_power_to_the_electric_network() {
            var aPowerPlant = new PowerPlant();
            var powerPlantConsumer = Substitute.For<Area>();
            aPowerPlant.AddPowerReceiver(powerPlantConsumer);

            aPowerPlant.SupplyPower();

            powerPlantConsumer.Received(1).ReceiveFrom(aPowerPlant, OneGigawatt);
        }
        
        [Test]
        public void supply_power_to_multiple_areas() {
            var aPowerPlant = new PowerPlant();
            var anAreaConsumer = Substitute.For<AreaPowerReceiver>();
            var anotherAreaConsumer = Substitute.For<AreaPowerReceiver>();
            aPowerPlant.AddPowerReceiver(anAreaConsumer);
            aPowerPlant.AddPowerReceiver(anotherAreaConsumer);

            aPowerPlant.SupplyPower();

            anAreaConsumer.Received(1).ReceiveFrom(aPowerPlant, Power.CreateMegawatts(500));
            anotherAreaConsumer.Received(1).ReceiveFrom(aPowerPlant, Power.CreateMegawatts(500));
        }
    }
}