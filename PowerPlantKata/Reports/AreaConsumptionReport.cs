using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerPlantKata.Reports {
    public class AreaConsumptionReport {
        public Guid AreaId { get; }
        public List<CityConsumptionReport> CityConsumptionReports { get; }

        public AreaConsumptionReport(Guid areaId, List<CityConsumptionReport> cityConsumptionReports) {
            AreaId = areaId;
            CityConsumptionReports = cityConsumptionReports;
        }

        protected bool Equals(AreaConsumptionReport other) {
            return AreaId.Equals(other.AreaId) 
                   && CityConsumptionReports.Count == other.CityConsumptionReports.Count
                   && CityConsumptionReports.All(report => other.CityConsumptionReports.Contains(report));
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AreaConsumptionReport) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (AreaId.GetHashCode() * 397) ^ (CityConsumptionReports != null ? CityConsumptionReports.GetHashCode() : 0);
            }
        }

        public Power ConsumedPower() {
            return CityConsumptionReports.Aggregate(Power.CreateKilowatts(0), (total, cityReport) => total + cityReport.ConsumedPower());
        }
    }
}