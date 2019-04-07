namespace PowerPlantKata {
    public class Power {
        private const long GigawattsInWatts = 1000000000;
        private const long MegawattsInWatts = 1000000;
        private const long KiloWattsInWatts = 1000;
        private long watts;


        public static Power CreateOneGigawatt() {
            return new Power(1, 0, 0);
        }

        public static Power CreateMegawatts(long megawatts) {
            return new Power(0, megawatts, 0);
        }

        public static Power CreateKilowatts(long kilowatts) {
            return new Power(0, 0 , kilowatts);
        }

        private Power(long gigawatts, long megawatts, long kiloWatts) {
            watts = GigawattsInWatts * gigawatts;
            watts += MegawattsInWatts * megawatts;
            watts += KiloWattsInWatts * kiloWatts;
        }

        private Power(long watts) {
            this.watts = watts;
        }

        public Power GetDividedFor(int divisionNumber) {
            var kilowattsDivided = watts / divisionNumber;
            return new Power(kilowattsDivided);
        }


        protected bool Equals(Power other) {
            return watts == other.watts;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Power) obj);
        }

        public override int GetHashCode() {
            return watts.GetHashCode();
        }
    }
}