using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abc.Domain.Quantity;

namespace Abc.Infra.Quantity
{
    public class MeasuresRepository: IMeasuresRepository
    {
        private readonly QuantityDbcontext db;
        public MeasuresRepository(QuantityDbcontext c)
        {
            db = c;

        }
        public Task<List<Measure>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Measure>> Get(string ID)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string ID)
        {
            throw new NotImplementedException();
        }

        public Task Add(Measure obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Measure obj)
        {
            throw new NotImplementedException();
        }
    }
}
