﻿using Abc.Data.Quantity;
using Abc.Domain.Quantity;

namespace Abc.Infra.Quantity
{
    public sealed class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {

        public UnitsRepository(QuantityDbContext c) : base(c, c.Units)
        {
        }
        protected internal override Unit ToDomainObject(UnitData d) => new Unit(d);
    
    }
}
