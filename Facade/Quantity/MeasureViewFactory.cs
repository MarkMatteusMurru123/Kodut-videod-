using System;
using System.Runtime.CompilerServices;
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
                var v = new MeasureView();
                v.ID = o.Data.ID;
                v.Name = o.Data.Name;
                v.Code = o.Data.Code;
                v.Definition = o.Data.Definition;
                v.Validfrom = o.Data.Validfrom;
                v.ValidTo = o.Data.ValidTo;

                return v;
            }
    }
}

