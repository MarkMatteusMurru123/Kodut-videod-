using System;
using System.Collections.Generic;
using System.Text;
using Abc.Data.Quantity;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra.Quantity
{
    public class QuantityDbcontext: DbContext
    {
        public QuantityDbcontext(DbContextOptions<QuantityDbcontext> options)
            : base(options)
        {
        }
        public DbSet<MeasureData> Measures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
            builder.Entity<MeasureData>().ToTable(nameof(Measures)); 
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<MeasureData>().ToTable(nameof(Measures));
        }
    }
}
