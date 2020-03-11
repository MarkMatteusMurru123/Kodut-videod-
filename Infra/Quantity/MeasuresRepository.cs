using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Abc.Infra.Quantity
{
    public class MeasuresRepository: UniqueEntityRepository <Measure, MeasureData>, IMeasuresRepository
    {

        public MeasuresRepository(QuantityDbcontext c) : base(c, c.Measures)
        {
        }

        protected internal override Measure ToDomainObject(MeasureData d) => new Measure(d);
        


        protected internal override IQueryable<MeasureData> AddFiltering(IQueryable<MeasureData> set)
        {
            if (string.IsNullOrEmpty(SearchString)) return set;
            return set.Where(s => s.Name.Contains(SearchString) 
                                  || s.Code.Contains(SearchString)
                                  || s.ID.Contains(SearchString)
                                  || s.Definition.Contains(SearchString)
                                  || s.ValidFrom.ToString().Contains(SearchString)
                                  || s.ValidTo.ToString().Contains(SearchString)
                                  );

        }
        


        
    }
}
