namespace PowerPlantKata {
    public class Electricity {
        private readonly int gigawatts;

        private Electricity(int gigawatts) {
            this.gigawatts = gigawatts;
        }

        public static Electricity CreateOneGigawatt() {
            return new Electricity(1);
        }


        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Electricity) obj);
        }

        public override int GetHashCode() {
            return gigawatts;
        }

        protected bool Equals(Electricity other) {
            return gigawatts == other.gigawatts;
        }
    }
}