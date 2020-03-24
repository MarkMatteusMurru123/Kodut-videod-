using System.Collections.Generic;
using System.Linq;
using Abc.Data.Quantity;

namespace Abc.Infra.Quantity
{
    public static class QuantityDbInitializer
    {
        internal static MeasureData Time = new MeasureData
        {
            Id = "Time", Name = "Time", Code = "t",
            Definition = "In physical science, time is defined as a measurement, " +
                         "or as what the clock face reads."
        };

        internal static MeasureData Length = new MeasureData
        {
            Id = "Length", Name = "Length", Code = "l",
            Definition = "The measurement or extent of something from end to end."
        };

        internal static MeasureData Mass = new MeasureData
        {
            Id = "Mass", Name = "Mass", Code = "m",
            Definition = "The quantity of matter which a body contains, as measured by "+
            "its acceleration under a given force or by the force exerted on "+
            "it by a gravitational field"
        };

        internal static MeasureData Current = new MeasureData
        {
            Id = "Current", Name = "Electric Current", Code = "I",
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
            Id = "Temperature", Name = "Thermodynamic Temperature", Code = "T",
            Definition = "Thermodynamic temperature is the absolute measure of temperature " +
                         "and is one of the principal parameters of thermodynamics."
        };

        internal static MeasureData Substance = new MeasureData
        {
            Id = "Substance", Name = "Amount of Substance", Code = "n",
            Definition = "In chemistry, the amount of substance in a given " +
                         "sample of matter is the number of discrete atomic-scale " +
                         "particles in it; where the particles may be molecules, " +
                         "atoms, ions, electrons, or other, depending on the context. " +
                         "It is sometimes referred to as the chemical amount."
        };

        internal static MeasureData Luminous = new MeasureData
        {
            Id = "Luminous", Name = "Luminous Intensity", Code = "Iv",
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
            CreateUnitData(Time.Id, centuriesName),
            CreateUnitData(Time.Id, decadesName),
            CreateUnitData(Time.Id, daysName),
            CreateUnitData(Time.Id, fortnightsName),
            CreateUnitData(Time.Id, hoursName, null, "h"),
            CreateUnitData(Time.Id, microsecondsName),
            CreateUnitData(Time.Id, millenniumName),
            CreateUnitData(Time.Id, millisecondsName),
            CreateUnitData(Time.Id, minutesName, null, "min"),
            CreateUnitData(Time.Id, monthsName),
            CreateUnitData(Time.Id, nanosecondsName),
            CreateUnitData(Time.Id, secondsName, null,  "sec"),
            CreateUnitData(Time.Id, weeksName),
            CreateUnitData(Time.Id, yearsName)
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
            CreateUnitData(Length.Id, astronomicalUnitsName),
            CreateUnitData(Length.Id, angstromsName),
            CreateUnitData(Length.Id, centimetersName),
            CreateUnitData(Length.Id, chainsName),
            CreateUnitData(Length.Id, cubitsName),
            CreateUnitData(Length.Id, decametersName),
            CreateUnitData(Length.Id, decimetersName),
            CreateUnitData(Length.Id, feetName),
            CreateUnitData(Length.Id, fathomsName),
            CreateUnitData(Length.Id, furlongsName),
            CreateUnitData(Length.Id, gigametersName),
            CreateUnitData(Length.Id, handsName),
            CreateUnitData(Length.Id, hectometersName),
            CreateUnitData(Length.Id, inchesName),
            CreateUnitData(Length.Id, kilometersName),
            CreateUnitData(Length.Id, lightYearsName),
            CreateUnitData(Length.Id, lightSecondsName),
            CreateUnitData(Length.Id, linksName),
            CreateUnitData(Length.Id, metersName),
            CreateUnitData(Length.Id, megametersName),
            CreateUnitData(Length.Id, micronsName),
            CreateUnitData(Length.Id, milesName),
            CreateUnitData(Length.Id, millimetersName),
            CreateUnitData(Length.Id, millimicronsName),
            CreateUnitData(Length.Id, nanometersName),
            CreateUnitData(Length.Id, nauticalMilesName),
            CreateUnitData(Length.Id, pacesName),
            CreateUnitData(Length.Id, parsecsName),
            CreateUnitData(Length.Id, picasName),
            CreateUnitData(Length.Id, pointsName),
            CreateUnitData(Length.Id, rodsName),
            CreateUnitData(Length.Id, yardsName),
            CreateUnitData(Length.Id, micromicronsName),
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
            CreateUnitData(Mass.Id, centigramsName),
            CreateUnitData(Mass.Id, decagramsName),
            CreateUnitData(Mass.Id, decigramsName),
            CreateUnitData(Mass.Id, dramsName),
            CreateUnitData(Mass.Id, grainsName),
            CreateUnitData(Mass.Id, gramsName, null, "g"),
            CreateUnitData(Mass.Id, hectogramsName),
            CreateUnitData(Mass.Id, kilogramsName, null, "kg"),
            CreateUnitData(Mass.Id, longTonsName),
            CreateUnitData(Mass.Id, metricTonsName, null, "T"),
            CreateUnitData(Mass.Id, microgramsName),
            CreateUnitData(Mass.Id, milligramsName),
            CreateUnitData(Mass.Id, nanogramsName),
            CreateUnitData(Mass.Id, ouncesName),
            CreateUnitData(Mass.Id, poundsName),
            CreateUnitData(Mass.Id, stonesName),
            CreateUnitData(Mass.Id, tonsName)
        }; internal static List<UnitData> CurrentUnits => new List<UnitData>
        {

        };
        public const string celsiusName = "Celsius";
        public const string fahrenheitName = "Fahrenheit";
        public const string kelvinName = "Kelvin";
        public const string rankineName = "Rankine";
        internal static List<UnitData> TemperatureUnits => new List<UnitData>
        {
            CreateUnitData(Temperature.Id, celsiusName, null, "°C"),
            CreateUnitData(Temperature.Id, fahrenheitName, null, "°F"),
            CreateUnitData(Temperature.Id, kelvinName, null, "K"),
            CreateUnitData(Temperature.Id, rankineName, null, "°R")

        };

        private static UnitData CreateUnitData(string measureId, string id, string name = null, string code = null)
        {
            return new UnitData
            {
                Id = id,
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
