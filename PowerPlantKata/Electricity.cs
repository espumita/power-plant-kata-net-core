namespace PowerPlantKata {
    public class Electricity {
        private const long GigawattsInWatts = 1000000000;
        private const long MegawattsInWatts = 1000000;
        private long watts;


        public static Electricity CreateOneGigawatt() {
            return new Electricity(1, 0);
        }

        public static Electricity GetMegawatts(int megawatts) {
            return new Electricity(0, megawatts);
        }
        private Electricity(long gigawatts, long megawatts) {
            watts = GigawattsInWatts * gigawatts;
            watts += MegawattsInWatts * megawatts;
        }

        private Electricity(long watts) {
            this.watts = watts;
        }

        public Electricity GetDividedFor(int divisionNumber) {
            var kilowattsDivided = watts / divisionNumber;
            return new Electricity(kilowattsDivided);
        }


        protected bool Equals(Electricity other) {
            return watts == other.watts;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Electricity) obj);
        }

        public override int GetHashCode() {
            return watts.GetHashCode();
        }
    }
}