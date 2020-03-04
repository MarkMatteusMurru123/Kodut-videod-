using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra.Quantity
{
    public class MeasuresRepository: PaginatedRepository<Measure, MeasureData>, IMeasuresRepository
    {

        public MeasuresRepository(QuantityDbcontext c) : base(c, c.Measures)
        {
        }
        public override async Task<List<Measure>> Get()
        {
            var list = await CreatePaged(CreateFiltered(CreateSorted()));
            HasNextPage = list.HasNextPage;
            HasPreviousPage = list.HasPreviousPage;
            return list.Select(e => new Measure(e)).ToList();
        }

        private async Task <PaginatedList<MeasureData>> CreatePaged(IQueryable<MeasureData> dataSet)
        {
            return await PaginatedList<MeasureData>.CreateAsync(
                dataSet, PageIndex , PageSize);
        }

        private IQueryable<MeasureData> CreateFiltered(IQueryable<MeasureData> set)
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
        private IQueryable<MeasureData> CreateSorted()
        {
            IQueryable<MeasureData> measures = from s in dbSet
                select s;

            switch (SortOrder)
            {
                case "name_desc":
                    measures= measures.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    measures = measures.OrderBy(s => s.ValidFrom);
                    break;
                case "date_desc":
                    measures = measures.OrderByDescending(s => s.ValidFrom);
                    break;
                default:
                    measures = measures.OrderBy(s => s.Name);
                    break;
            }
            return measures.AsNoTracking();
        }


        
    }
}
