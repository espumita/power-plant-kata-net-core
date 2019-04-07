using System.Collections.Generic;
using PowerPlantKata.PowerProducers;
using PowerPlantKata.PowerReceivers;
using PowerPlantKata.Reports;

namespace PowerPlantKata {
    public class PowerPlant : PowerProducer<AreaPowerReceiver> {
        private readonly Power power = Power.CreateOneGigawatt();
        private List<AreaPowerReceiver> powerReceivers;
        private List<AreaConsumptionReport> consumptionReports;
        
        public PowerPlant() {
            powerReceivers = new List<AreaPowerReceiver>();
            consumptionReports = new List<AreaConsumptionReport>();
        }

        public void AddPowerReceiver(AreaPowerReceiver powerReceiver) {
            powerReceivers.Add(powerReceiver);
        }

        public void SupplyPower() {
            var powerForEachReceiver = power.GetDividedFor(powerReceivers.Count);
            powerReceivers.ForEach(consumer => consumer.ReceiveFrom(this, powerForEachReceiver));
        }


        public virtual void GetNotifiedOfElectricConsumeOff(AreaConsumptionReport consumptionReport) {
            consumptionReports.Add(consumptionReport);
        }

        public PowerPlantConsumptionReport GetMonthlyReport() {
            return new PowerPlantConsumptionReport(consumptionReports, power);
        }
    }
}