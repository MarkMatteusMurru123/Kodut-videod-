using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra.Quantity
{
    public class MeasuresRepository: IMeasuresRepository
    {
        private readonly QuantityDbcontext db;
        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public int PageSize { get; set;} = 1;
        public int PageIndex { get; set; } = 1;
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

        public MeasuresRepository(QuantityDbcontext c)
        {
            db = c;

        }
        public async Task<List<Measure>> Get()
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
            IQueryable<MeasureData> measures = from s in db.Measures
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

        public async Task<Measure> Get(string ID)
        {
            var d = await db.Measures.FirstOrDefaultAsync(m => m.ID == ID);
            return new Measure(d);

        }

        public async Task Delete(string ID)
        {
            var d = await db.Measures.FindAsync(ID);
            if (ID is null)
                return;
            db.Measures.Remove(d);
            await db.SaveChangesAsync();
        }

        public async Task Add(Measure obj)
        {
            db.Measures.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public async Task Update(Measure obj)
        {
            var d = await db.Measures.FirstOrDefaultAsync(x=> x.ID == obj.Data.ID);
            d.Code = obj.Data.Code;
            d.Name = obj.Data.Name;
            d.Definition = obj.Data.Definition;
            d.ValidTo = obj.Data.ValidTo;
            d.ValidFrom = obj.Data.ValidFrom;
            db.Measures.Update(d);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MeasureViewExists(MeasureView.ID))
                //{
               //     return NotFound();
                //}
                //else
                //{
                    throw;
               // }
            }
    
        }
    }
}
