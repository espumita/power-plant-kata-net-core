using System;
using System.Collections.Generic;

namespace PowerPlantKata.Reports {
    public class CityConsumptionReport {
        public Guid cityId { get; }
        public List<BuildingConsumptionReport> buildingConsumptionReports { get; }

        public CityConsumptionReport(Guid cityId, List<BuildingConsumptionReport> buildingConsumptionReports) {
            this.cityId = cityId;
            this.buildingConsumptionReports = buildingConsumptionReports;
        }


        protected bool Equals(CityConsumptionReport other) {
            return cityId.Equals(other.cityId) && Equals(buildingConsumptionReports, other.buildingConsumptionReports);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CityConsumptionReport) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (cityId.GetHashCode() * 397) ^ (buildingConsumptionReports != null ? buildingConsumptionReports.GetHashCode() : 0);
            }
        }
    }
}