using System;

namespace PowerPlantKata.Reports {
    public class BuildingConsumptionReport {
        public Guid BuildingId { get; }
        public Power Power { get; }

        public BuildingConsumptionReport(Guid buildingId, Power power) {
            BuildingId = buildingId;
            Power = power;
        }

        protected bool Equals(BuildingConsumptionReport other) {
            return BuildingId.Equals(other.BuildingId) && Equals(Power, other.Power);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BuildingConsumptionReport) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (BuildingId.GetHashCode() * 397) ^ (Power != null ? Power.GetHashCode() : 0);
            }
        }
    }
}