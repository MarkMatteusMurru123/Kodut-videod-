using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra.Quantity
{
    public class MeasuresRepository: IMeasuresRepository
    {
        private readonly QuantityDbcontext db;
        public MeasuresRepository(QuantityDbcontext c)
        {
            db = c;

        }
        public async Task<List<Measure>> Get()
        {
            var l = await db.Measures.ToListAsync();
            return l.Select(e => new Measure(e)).ToList();
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
            d.Validfrom = obj.Data.Validfrom;
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
