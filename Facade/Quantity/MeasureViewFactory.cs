using Abc.Data.Quantity;
using Abc.Domain.Quantity;

namespace Facade.Quantity
{
    public static class MeasureViewFactory
    {
        public static Measure Create(MeasureView v) //viewde transport
        {
            var d = new MeasureData
            {
                ID = v.ID,
                Name = v.Name,
                Code = v.Code,
                Definition = v.Definition,
                Validfrom = v.Validfrom,
                ValidTo = v.ValidTo
            };
            return new Measure(d);

        }
        public static MeasureView Create(Measure o)
            {
            var v = new MeasureView
            {
                ID = o.Data.ID,
                Name = o.Data.Name,
                Code = o.Data.Code,
                Definition = o.Data.Definition,
                Validfrom = o.Data.Validfrom,
                ValidTo = o.Data.ValidTo
            };

            return v;
            }
    }
}

