using System.Collections.Generic;
using System.Linq;
using Abc.Data.Quantity;

namespace Abc.Infra.Quantity
{
    public static class QuantityDbInitializer
    {
        internal static MeasureData Time = new MeasureData
        {
            ID = "Time", Name = "Time", Code = "t",
            Definition = "In physical science, time is defined as a measurement, " +
                         "or as what the clock face reads."
        };

        internal static MeasureData Length = new MeasureData
        {
            ID = "Length", Name = "Length", Code = "l",
            Definition = "The measurement or extent of something from end to end."
        };

        internal static MeasureData Mass = new MeasureData
        {
            ID = "Mass", Name = "Mass", Code = "m",
            Definition = "The quantity of matter which a body contains, as measured by "+
            "its acceleration under a given force or by the force exerted on "+
            "it by a gravitational field"
        };

        internal static MeasureData Current = new MeasureData
        {
            ID = "Current", Name = "Electric Current", Code = "I",
            Definition = "An electric current is the rate of flow of electric charge " +
                         "past a point or region. An electric current is said to exist " +
                         "when there is a net flow of electric charge through a region." +
                         "In electric circuits this charge is often carried by electrons " +
                         "moving through a wire. It can also be carried by ions in an " +
                         "electrolyte, or by both ions and electrons such as in an " +
                         "ionized gas (plasma)"
        };

        internal static MeasureData Temperature = new MeasureData
        {
            ID = "Temperature", Name = "Thermodynamic Temperature", Code = "T",
            Definition = "Thermodynamic temperature is the absolute measure of temperature " +
                         "and is one of the principal parameters of thermodynamics."
        };

        internal static MeasureData Substance = new MeasureData
        {
            ID = "Substance", Name = "Amount of Substance", Code = "n",
            Definition = "In chemistry, the amount of substance in a given " +
                         "sample of matter is the number of discrete atomic-scale " +
                         "particles in it; where the particles may be molecules, " +
                         "atoms, ions, electrons, or other, depending on the context. " +
                         "It is sometimes referred to as the chemical amount."
        };

        internal static MeasureData Luminous = new MeasureData
        {
            ID = "Luminous", Name = "Luminous Intensity", Code = "Iv",
            Definition = "In photometry, luminous intensity is a measure of the " +
                         "wavelength-weighted power emitted by a light source in a " +
                         "particular direction per unit solid angle, based on the " +
                         "luminosity function, a standardized model of the sensitivity " +
                         "of the human eye"
        };

        internal static List<MeasureData> Measures => new List<MeasureData> {
            Time, Length, Mass, Current, Temperature, Substance, Luminous
        };

        public const string nanosecondsName = "Nanoseconds";
        public const string microsecondsName = "Microseconds";
        public const string millisecondsName = "Milliseconds";
        public const string secondsName = "Seconds";
        public const string minutesName = "Minutes";
        public const string hoursName = "Hours";
        public const string daysName = "Days";
        public const string weeksName = "Weeks";
        public const string fortnightsName = "Fortnights";
        public const string monthsName = "Months";
        public const string yearsName = "Years";
        public const string decadesName = "Decades";
        public const string centuriesName = "Centuries";
        public const string millenniumName = "Millennium";

        internal static List<UnitData> TimeUnits => new List<UnitData> {
            CreateUnitData(Time.ID, centuriesName),
            CreateUnitData(Time.ID, decadesName),
            CreateUnitData(Time.ID, daysName),
            CreateUnitData(Time.ID, fortnightsName),
            CreateUnitData(Time.ID, hoursName, null, "h"),
            CreateUnitData(Time.ID, microsecondsName),
            CreateUnitData(Time.ID, millenniumName),
            CreateUnitData(Time.ID, millisecondsName),
            CreateUnitData(Time.ID, minutesName, null, "min"),
            CreateUnitData(Time.ID, monthsName),
            CreateUnitData(Time.ID, nanosecondsName),
            CreateUnitData(Time.ID, secondsName, null,  "sec"),
            CreateUnitData(Time.ID, weeksName),
            CreateUnitData(Time.ID, yearsName)
        };

        public const string astronomicalUnitsName = "AstronomicalUnits";
        public const string angstromsName = "Angstroms";
        public const string centimetersName = "Centimeters";
        public const string chainsName = "Chains";
        public const string cubitsName = "Cubits";
        public const string decametersName = "Decameters";
        public const string decimetersName = "Decimeters";
        public const string feetName = "Feet";
        public const string fathomsName = "Fathoms";
        public const string furlongsName = "Furlongs";
        public const string gigametersName = "Gigameters";
        public const string handsName = "Hands";
        public const string hectometersName = "Hectometers";
        public const string inchesName = "Inches";
        public const string kilometersName = "Kilometers";
        public const string lightYearsName = "LightYears";
        public const string lightSecondsName = "LightSeconds";
        public const string linksName = "Links";
        public const string metersName = "Meters";
        public const string micromicronsName = "Micromicrons";
        public const string megametersName = "Megameters";
        public const string micronsName = "Microns";
        public const string milesName = "Miles";
        public const string millimetersName = "Millimeters";
        public const string millimicronsName = "Millimicrons";
        public const string nanometersName = "Nanometers";
        public const string nauticalMilesName = "NauticalMiles";
        public const string pacesName = "Paces";
        public const string parsecsName = "Parsecs";
        public const string picasName = "Picas";
        public const string pointsName = "Points";
        public const string rodsName = "Rods";
        public const string yardsName = "Yards";
        internal static List<UnitData> LengthUnits => new List<UnitData>
        {
            CreateUnitData(Length.ID, astronomicalUnitsName),
            CreateUnitData(Length.ID, angstromsName),
            CreateUnitData(Length.ID, centimetersName),
            CreateUnitData(Length.ID, chainsName),
            CreateUnitData(Length.ID, cubitsName),
            CreateUnitData(Length.ID, decametersName),
            CreateUnitData(Length.ID, decimetersName),
            CreateUnitData(Length.ID, feetName),
            CreateUnitData(Length.ID, fathomsName),
            CreateUnitData(Length.ID, furlongsName),
            CreateUnitData(Length.ID, gigametersName),
            CreateUnitData(Length.ID, handsName),
            CreateUnitData(Length.ID, hectometersName),
            CreateUnitData(Length.ID, inchesName),
            CreateUnitData(Length.ID, kilometersName),
            CreateUnitData(Length.ID, lightYearsName),
            CreateUnitData(Length.ID, lightSecondsName),
            CreateUnitData(Length.ID, linksName),
            CreateUnitData(Length.ID, metersName),
            CreateUnitData(Length.ID, megametersName),
            CreateUnitData(Length.ID, micronsName),
            CreateUnitData(Length.ID, milesName),
            CreateUnitData(Length.ID, millimetersName),
            CreateUnitData(Length.ID, millimicronsName),
            CreateUnitData(Length.ID, nanometersName),
            CreateUnitData(Length.ID, nauticalMilesName),
            CreateUnitData(Length.ID, pacesName),
            CreateUnitData(Length.ID, parsecsName),
            CreateUnitData(Length.ID, picasName),
            CreateUnitData(Length.ID, pointsName),
            CreateUnitData(Length.ID, rodsName),
            CreateUnitData(Length.ID, yardsName),
            CreateUnitData(Length.ID, micromicronsName),
        };


        public const string centigramsName = "Centigrams";
        public const string decagramsName = "Decagrams";
        public const string decigramsName = "Decigrams";
        public const string dramsName = "Drams";
        public const string grainsName = "Grains";
        public const string gramsName = "Grams";
        public const string hectogramsName = "Hectograms";
        public const string kilogramsName = "Kilograms";
        public const string longTonsName = "LongTons";
        public const string metricTonsName = "MetricTons";
        public const string microgramsName = "Micrograms";
        public const string milligramsName = "Milligrams";
        public const string nanogramsName = "Nanograms";
        public const string ouncesName = "Ounces";
        public const string poundsName = "Pounds";
        public const string stonesName = "Stones";
        public const string tonsName = "Tons";
        internal static List<UnitData> MassUnits => new List<UnitData>
        {
            CreateUnitData(Mass.ID, centigramsName),
            CreateUnitData(Mass.ID, decagramsName),
            CreateUnitData(Mass.ID, decigramsName),
            CreateUnitData(Mass.ID, dramsName),
            CreateUnitData(Mass.ID, grainsName),
            CreateUnitData(Mass.ID, gramsName, null, "g"),
            CreateUnitData(Mass.ID, hectogramsName),
            CreateUnitData(Mass.ID, kilogramsName, null, "kg"),
            CreateUnitData(Mass.ID, longTonsName),
            CreateUnitData(Mass.ID, metricTonsName, null, "T"),
            CreateUnitData(Mass.ID, microgramsName),
            CreateUnitData(Mass.ID, milligramsName),
            CreateUnitData(Mass.ID, nanogramsName),
            CreateUnitData(Mass.ID, ouncesName),
            CreateUnitData(Mass.ID, poundsName),
            CreateUnitData(Mass.ID, stonesName),
            CreateUnitData(Mass.ID, tonsName)
        }; internal static List<UnitData> CurrentUnits => new List<UnitData>
        {

        };
        public const string celsiusName = "Celsius";
        public const string fahrenheitName = "Fahrenheit";
        public const string kelvinName = "Kelvin";
        public const string rankineName = "Rankine";
        internal static List<UnitData> TemperatureUnits => new List<UnitData>
        {
            CreateUnitData(Temperature.ID, celsiusName, null, "°C"),
            CreateUnitData(Temperature.ID, fahrenheitName, null, "°F"),
            CreateUnitData(Temperature.ID, kelvinName, null, "K"),
            CreateUnitData(Temperature.ID, rankineName, null, "°R")

        };

        private static UnitData CreateUnitData(string measureId, string id, string name = null, string code = null)
        {
            return new UnitData
            {
                ID = id,
                MeasureId = measureId,
                Name = name?? id, //kui tühi, siis saab id väärtuse
                Code = code

            };
        }

        internal static List<UnitData> SubstanceUnits => new List<UnitData>
        {

        }; internal static List<UnitData> LuminousUnits => new List<UnitData>
        {

        };
        public static void Initialize(QuantityDbcontext db)
        {
            InitializeMeasures(db);
            InitializeUnits(db);
           
        }

        private static void InitializeUnits(QuantityDbcontext db)
        {
            if (db.Units.Count()!= 0) return;
            db.Units.AddRange(TimeUnits);
            db.Units.AddRange(LengthUnits);
            db.Units.AddRange(MassUnits);
            db.Units.AddRange(CurrentUnits);
            db.Units.AddRange(SubstanceUnits);
            db.Units.AddRange(LuminousUnits);
            db.Units.AddRange(TemperatureUnits);
            db.SaveChanges();
        }

        private static void InitializeMeasures(QuantityDbcontext db)
        {
            if (db.Measures.Count()!= 0) return;
            db.Measures.AddRange(Measures);
            db.SaveChanges();
        }
    }
}
