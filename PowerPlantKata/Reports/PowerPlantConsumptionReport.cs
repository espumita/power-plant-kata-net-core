using System.Collections.Generic;
using System.Linq;

namespace PowerPlantKata.Reports {
    public class PowerPlantConsumptionReport {
        public List<AreaConsumptionReport> AreasReport { get; }
        public Power TotalGeneratedPower { get; }

        public PowerPlantConsumptionReport(List<AreaConsumptionReport> areasReport, Power totalGeneratedPower) {
            AreasReport = areasReport;
            TotalGeneratedPower = totalGeneratedPower;
        }


        public Power TotalConsumedPower() {
            return AreasReport.Aggregate(Power.CreateKilowatts(0), (total, areaReport) => total + areaReport.ConsumedPower());
        }
    }
}