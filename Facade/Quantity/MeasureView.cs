using System;

namespace Facade.Quantity
{
    public class MeasureView
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Definition { get; set; }
        public DateTime? Validfrom { get; set; }
        public DateTime? ValidTo { get; set; }

    }
}
