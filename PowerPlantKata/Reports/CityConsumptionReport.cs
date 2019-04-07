using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerPlantKata.Reports {
    public class CityConsumptionReport {
        public Guid cityId { get; }
        public List<BuildingConsumptionReport> BuildingConsumptionReports { get; }

        public CityConsumptionReport(Guid cityId, List<BuildingConsumptionReport> buildingConsumptionReports) {
            this.cityId = cityId;
            this.BuildingConsumptionReports = buildingConsumptionReports;
        }


        protected bool Equals(CityConsumptionReport other) {
            return cityId.Equals(other.cityId) && Equals(BuildingConsumptionReports, other.BuildingConsumptionReports);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CityConsumptionReport) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (cityId.GetHashCode() * 397) ^ (BuildingConsumptionReports != null ? BuildingConsumptionReports.GetHashCode() : 0);
            }
        }

        public Power ConsumedPower() {
            return BuildingConsumptionReports.Aggregate(Power.CreateKilowatts(0), (total, buildingReport) => total + buildingReport.Power);
        }
    }
}